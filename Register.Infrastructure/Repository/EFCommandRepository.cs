using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Register.Domain;
using System.Linq.Expressions;

namespace Register.Infrastructure;

public class EFCommandRepository<T> : ICommandRepository<T> where T : class
{
    private readonly DbContext _context;

    public EFCommandRepository(DbContext context) => _context = context;

    private DbSet<T> Set => _context.CommandSet<T>();

    public void Add(T entity) => Set.Add(entity);

    public Task AddAsync(T entity) => Set.AddAsync(entity).AsTask();

    public void Delete(object key)
    {
        var item = Set.Find(key);

        if (item is null) return;

        Set.Remove(item);
    }
    
    public void Delete(Expression<Func<T, bool>> where)
    {
        var items = Set.Where(where);

        if (!items.Any()) return;

        Set.RemoveRange(items);
    }

    public Task DeleteAsync(object key) => Task.Run(() => Delete(key));

    public Task DeleteAsync(Expression<Func<T, bool>> where) => Task.Run(() => Delete(where));

    public void Update(T entity)
    {
        var primaryKeyValues = _context.PrimaryKeyValues<T>(entity);

        var item = Set.Find(primaryKeyValues);

        if (item is null) return;

        _context.Entry(item).State = EntityState.Detached;

        _context.Update(entity);
    }

    public Task UpdateAsync(T entity) => Task.Run(() => Update(entity));
}
