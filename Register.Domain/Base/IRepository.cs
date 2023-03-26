using System.Linq.Expressions;

namespace Register.Domain;

public interface IRepository<T> where T : class
{
    IQueryable<T> Queryable { get; }

    Task<IEnumerable<T>> ListAsync();

    Task<T> GetByIdAsync(long id);

    Task<bool> AnyAsync(Expression<Func<T, bool>> where);

    Task AddAsync(T item);

    Task UpdateAsync(T item);

    Task DeleteAsync(object key);
}
