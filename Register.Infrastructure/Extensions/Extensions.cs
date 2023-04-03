using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Register.Infrastructure;

public static class Extensions
{
    public static void AddContext<T>(this IServiceCollection services, Action<DbContextOptionsBuilder> options) where T : DbContext
    {
        services.AddDbContext<T>(options);

        services.AddScoped<IUnitOfWork, UnitOfWork<T>>();
    }

    public static DbContext DetectChangesLazyLoading(this DbContext context, bool enabled)
    {
        context.ChangeTracker.AutoDetectChangesEnabled = enabled;

        context.ChangeTracker.LazyLoadingEnabled = enabled;
        
        context.ChangeTracker.QueryTrackingBehavior = enabled ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking;

        return context;
    }

    public static IQueryable<T> QuerySet<T>(this DbContext context) where T : class => context.DetectChangesLazyLoading(false).Set<T>().AsNoTracking();

    public static DbSet<T> CommandSet<T>(this DbContext context) where T : class => context.DetectChangesLazyLoading(true).Set<T>();

    public static object[] PrimaryKeyValues<T>(this DbContext context, object entity) => context.Model.FindEntityType(typeof(T))?.FindPrimaryKey()?.Properties.Select(property => entity.GetType().GetProperty(property.Name)?.GetValue(entity, default)).ToArray();
}
