namespace Register.Domain;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> ListAsync();

    Task<T> GetByIdAsync(long id);

    Task AddAsync(T item);

    void Update(T item);

    void Delete(object key);
}
