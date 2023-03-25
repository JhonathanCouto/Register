namespace Register.Infrastructure;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
