using Microsoft.EntityFrameworkCore;
using Register.Domain;

namespace Register.Infrastructure;

public class EFRepository<T> : Repository<T> where T : class
{
    public EFRepository(DbContext context) : base(new EFCommandRepository<T>(context), new EFQueryRepository<T>(context)) { }
}
