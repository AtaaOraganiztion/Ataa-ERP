using Infrastructure.Dependencies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services
            .AddRepositories()
            .AddMailServices(configuration)
            .AddFileServices(configuration)
            .AddExcelServices(configuration)
            .AddVideoUploadServices()
            .AddDatabase(configuration)
            .AddDataSeeder()
            .AddAuthenticationInternal(configuration)
            .AddHealthChecks(configuration);
}