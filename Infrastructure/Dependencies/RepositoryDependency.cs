using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies;

public static class RepositoryDependency
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        
        services.AddScoped<IUrlService, UrlService>();

        return services;
    }
}
