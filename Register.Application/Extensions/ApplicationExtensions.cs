using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;
using Scrutor;
using Microsoft.Extensions.Configuration;

namespace Register.Application;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }

    public static void AddClassesMatchingInterfaces(this IServiceCollection services, string @namespace)
    {
        var assemblies = DependencyContext.Default.GetDefaultAssemblyNames().Where(assembly => assembly.FullName.StartsWith(@namespace)).Select(Assembly.Load);

        services.Scan(scan => scan.FromAssemblies(assemblies).AddClasses().UsingRegistrationStrategy(RegistrationStrategy.Skip).AsMatchingInterface().WithScopedLifetime());
    }
}