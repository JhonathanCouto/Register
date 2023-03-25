using Register.Domain;

namespace Register.Infrastructure;

public sealed class UserRepository : EfRepository<User>, IUserRepository
{
    public UserRepository(Context context) : base(context) { }
}
