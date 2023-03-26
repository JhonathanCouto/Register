using Register.Domain;

namespace Register.Infrastructure;

public interface IUserRepository : IRepository<User>
{
    Task<bool> EmailExistsAsync(string email);
}
