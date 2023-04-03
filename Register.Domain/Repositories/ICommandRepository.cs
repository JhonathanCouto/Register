using System.Linq.Expressions;

namespace Register.Domain;

public interface ICommandRepository<T> where T : class
{
    void Add(T entity);

    Task AddAsync(T entity);

    void Delete(object key);

    void Delete(Expression<Func<T, bool>> where);

    Task DeleteAsync(object key);

    Task DeleteAsync(Expression<Func<T, bool>> where);

    void Update(T entity);

    Task UpdateAsync(T entity);
}
