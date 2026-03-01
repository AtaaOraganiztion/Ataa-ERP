using Infrastructure.Database.Seeders;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies;

public static class DataSeederDependency
{
    public static IServiceCollection AddDataSeeder(this IServiceCollection services)
    {
        services.AddScoped<IdentitiesDataSeeder>();
        services.AddScoped<SectorDataSeeder>();

        return services;
    }
}
