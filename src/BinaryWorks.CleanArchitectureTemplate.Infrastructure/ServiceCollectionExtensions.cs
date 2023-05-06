using System.Reflection;
using Auth0.AspNetCore.Authentication;
using BinaryWorks.CleanArchitectureTemplate.Application.Interfaces;
using BinaryWorks.CleanArchitectureTemplate.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BinaryWorks.CleanArchitectureTemplate.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static readonly Assembly Assembly = typeof(ServiceCollectionExtensions).Assembly;

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure Auth0
        // Uncomment the following lines to enable Auth0 integration. Note you will need to setup the Auth0 configuration in appsettings.json
        // and create the Auth0 account and application.
        // Ref: Blazor - https://auth0.com/blog/what-is-blazor-tutorial-on-building-webapp-with-authentication/
        // Ref: Web API - https://auth0.com/docs/quickstart/backend/aspnet-core-webapi/01-authorization
        // services
        //     .AddAuth0WebAppAuthentication(options => {
        //         options.Domain = configuration["Auth0:Domain"];
        //         options.ClientId = configuration["Auth0:ClientId"];
        //         options.CallbackPath = configuration["Auth0:CallbackPath"];
        //         options.Scope = configuration["Auth0:Scope"];
        //     });

        // Use SQLite Database
        var connectionString = configuration.GetConnectionString("Sqlite");
        ArgumentNullException.ThrowIfNull(connectionString);
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
        
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        services.AddHttpContextAccessor();

        services.AddScoped<ICurrentUserService, CurrentUserService>();
        
        return services;
    }
}
