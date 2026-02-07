using Application.Abstractions.Services;
using Infrastructure.Services;
using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies;

public static class ExcelDependency
{
    public static IServiceCollection AddExcelServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IExcelService, ExcelService>();

        return services;
    }
}
