using Microsoft.EntityFrameworkCore;
using Register.Domain;

namespace Register.Infrastructure;

public class EfRepository<T> : IRepository<T> where T : Entity
{
    private readonly DbContext _context;

    public EfRepository(DbContext context) => _context = context;

    private DbSet<T> Set => _context.Set<T>();

    public async Task AddAsync(T item) => await Set.AddAsync(item);

    public void Delete(object key)
    {
        var item = Set.Find(key);

        if (item is null) return;

        Set.Remove(item);
    }

    public async Task<T> GetByIdAsync(long id) => await Set.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<T>> ListAsync() => await Set.ToListAsync();
    
    public void Update(T item)
    {
        Set.Find(item.Id);

        Set.Update(item);
    }

}
