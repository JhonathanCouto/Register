using System.Linq.Expressions;

namespace Register.Domain;

public abstract class Repository<T> : IRepository<T> where T : class
{
    private readonly ICommandRepository<T> _commandRepository;
    private readonly IQueryRepository<T> _queryRepository;

    protected Repository
    (
        ICommandRepository<T> commandRepository, 
        IQueryRepository<T> queryRepository
    )
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
    }

    public IQueryable<T> Queryable => _queryRepository.Queryable;

    public void Add(T entity) => _commandRepository.Add(entity);

    public Task AddAsync(T entity) => _commandRepository.AddAsync(entity);

    public bool Any() => _queryRepository.Any();

    public bool Any(Expression<Func<T, bool>> where) => _queryRepository.Any(where);

    public Task<bool> AnyAsync() => _queryRepository.AnyAsync();

    public Task<bool> AnyAsync(Expression<Func<T, bool>> where) => _queryRepository.AnyAsync(where);

    public void Delete(object key) => _commandRepository.Delete(key);

    public void Delete(Expression<Func<T, bool>> where) => _commandRepository.DeleteAsync(where);

    public Task DeleteAsync(object key) => _commandRepository.DeleteAsync(key);

    public Task DeleteAsync(Expression<Func<T, bool>> where) => _commandRepository.DeleteAsync(where); 
    
    public T Get(object key) => _queryRepository.Get(key);
    
    public Task<T> GetAsync(object key) => _queryRepository.GetAsync(key);  

    public IEnumerable<T> List() => _queryRepository.List();

    public Task<IEnumerable<T>> ListAsync() => _queryRepository.ListAsync();    

    public void Update(T entity) => _commandRepository.Update(entity);  

    public Task UpdateAsync(T entity) => _commandRepository.UpdateAsync(entity);
}
