using Microsoft.EntityFrameworkCore;
using Register.Domain;

namespace Register.Infrastructure;

public sealed class UserRepository : EFRepository<User>, IUserRepository
{
    public UserRepository(Context context) : base(context) { }

    public Task<bool> EmailExistsAsync(string email) => Queryable.AnyAsync(user => user.Email == email);
}
