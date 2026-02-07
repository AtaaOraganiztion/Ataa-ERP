using Application.Abstractions.Services;
using Infrastructure.Services;
using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dependencies;

public static class MailDependency
{
    public static IServiceCollection AddMailServices(this IServiceCollection services, IConfiguration configuration)
    {
        // services.AddSingleton(configuration.GetSection("Mail").Get<MailSetting>()!);
        // services.AddScoped<IEmailService, EmailService>();

        return services;
    }
}
