using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BinaryWorks.CleanArchitectureTemplate.Application;

public static class ServiceCollectionExtensions
{
    public static readonly Assembly Assembly = typeof(ServiceCollectionExtensions).Assembly;

    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly));
        return services;
    }
}