using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Register.Infrastructure;

public static class DataExtension
{
    public static void AddDataExtension<T>(this IServiceCollection services) where T : DbContext
    {
        services.AddScoped<IUnitOfWork, UnitOfWork<T>>();
    }
}
