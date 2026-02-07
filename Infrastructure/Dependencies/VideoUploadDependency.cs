using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies;

public static class VideoUploadDependency
{
    public static IServiceCollection AddVideoUploadServices(this IServiceCollection services)
    {
        // FFmpeg.SetExecutablesPath(Path.Combine(AppContext.BaseDirectory, "ffmpeg"));
        //
        // services.Configure<IISServerOptions>(options =>
        // {
        //     options.MaxRequestBodySize = 100 * 1024 * 1024; // 100MB
        // });
        //
        // services.Configure<KestrelServerOptions>(options =>
        // {
        //     options.Limits.MaxRequestBodySize = 100 * 1024 * 1024; // 100MB
        // });
        //
        // services.AddScoped<IVideoService, VideoService>();
        
        
        return services;
    }
}