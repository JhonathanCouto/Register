using Microsoft.EntityFrameworkCore;
using Register.Domain;
using System.Linq.Expressions;

namespace Register.Infrastructure;

public class EfRepository<T> : IRepository<T> where T : Entity
{
    private readonly DbContext _context;

    public EfRepository(DbContext context) => _context = context;

    public IQueryable<T> Queryable => _context.Set<T>();

    private DbSet<T> Set => _context.Set<T>();

    public async Task AddAsync(T item) => await Set.AddAsync(item);

    public Task<bool> AnyAsync(Expression<Func<T, bool>> where) => Queryable.AnyAsync(where);

    public Task DeleteAsync(object key)
    {
        return Task.Run(() =>
        {
            var item = Set.Find(key);

            if (item is null) return;

            Set.Remove(item);
        });
    }

    public async Task<T> GetByIdAsync(long id) => await Queryable.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<T>> ListAsync() => await Queryable.ToListAsync();

    public Task UpdateAsync(T item)
    {
        return Task.Run(() =>
        {
            var teste = Set.Find(item.Id);

            Set.Update(item);
        });
    }

}
