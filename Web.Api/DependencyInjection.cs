using Application.Abstractions;
using Application.Abstractions.Services;
using Infrastructure.Authentication;
using Infrastructure.Services;
using Web.Api.Infrastructure;

namespace Web.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
        services.AddScoped<IEmailService, EmailService>();
        return services;
    }
}
