using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace Web.Api.Extensions;

public static class LocalizationExtensions
{
    public static IServiceCollection AddLocalizationServices(this IServiceCollection services)
    {
        services.AddLocalization(options => options.ResourcesPath = "");
        services.Configure<RequestLocalizationOptions>(options =>
        {
            CultureInfo[] supportedCultures =
            [
                new("en-US"),
                new("ar-EG")
            ];

            options.DefaultRequestCulture = new RequestCulture("en");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });

        return services;
    }

    public static IApplicationBuilder UseLocalization(this IApplicationBuilder app)
    {
        IOptions<RequestLocalizationOptions>? localizationOptions =
            app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
        if (localizationOptions?.Value != null)
        {
            app.UseRequestLocalization(localizationOptions.Value);
        }

        return app;
    }
}
