using Application.Abstractions.Services;
using Infrastructure.Services;
using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies;

public static class FileDependency
{
    public static IServiceCollection AddFileServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(services.AddSingleton(configuration.GetSection("Server").Get<ServerSetting>()!));
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IUploadImage, UploadImage>();

        return services;
    }
}
