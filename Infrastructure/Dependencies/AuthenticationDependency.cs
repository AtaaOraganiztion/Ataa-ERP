using System.Security.Claims;
using System.Text;
using Application.Abstractions.Authentication;
using Infrastructure.Authentication;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Dependencies;

public static class AuthenticationDependency
{
    public static IServiceCollection AddAuthenticationInternal(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Register Ulid type converter for ASP.NET Core Identity
        TypeDescriptor.AddAttributes(typeof(Ulid), new TypeConverterAttribute(typeof(UlidTypeConverter)));
        
        services.AddSingleton(configuration.GetSection("Jwt").Get<JwtSetting>()!);
        services.AddSingleton(configuration.GetSection("DataProtectionTokenProvider")
            .Get<DataProtectionTokenProviderSetting>()!);

        JwtSetting jwtSettings = configuration.GetSection("Jwt").Get<JwtSetting>()!;
        DataProtectionTokenProviderSetting dataProtectionTokenProviderSetting = configuration
            .GetSection("DataProtectionTokenProvider")
            .Get<DataProtectionTokenProviderSetting>()!;


        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // .AddCookie().AddGoogle(options =>
            // {
            //     var clientId = configuration["Authentication:Google:ClientId"];
            //
            //     if (clientId == null)
            //     {
            //         throw new ArgumentNullException(nameof(clientId));
            //     }
            //
            //     var clientSecret = configuration["Authentication:Google:ClientSecret"];
            //
            //     if (clientSecret == null)
            //     {
            //         throw new ArgumentNullException(nameof(clientSecret));
            //     }
            //
            //     options.ClientId = clientId;
            //     options.ClientSecret = clientSecret;
            //     options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //
            // })
            // .AddFacebook(options =>
            // {
            //     var appId = configuration["Authentication:Facebook:AppId"];
            //
            //     if (appId == null)
            //     {
            //         throw new ArgumentNullException(nameof(appId));
            //     }
            //
            //     var appSecret = configuration["Authentication:Facebook:AppSecret"];
            //
            //     if (appSecret == null)
            //     {
            //         throw new ArgumentNullException(nameof(appSecret));
            //     }
            //
            //     options.AppId = appId;
            //     options.AppSecret = appSecret;
            //     options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //
            // })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = jwtSettings.RequireHttpsMetadata;
                options.SaveToken = jwtSettings.SaveToken;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidAudience = jwtSettings.Audience,
                    ValidateLifetime = jwtSettings.ValidateLifetime,
                    ClockSkew = TimeSpan.Zero,
                    NameClaimType = ClaimTypes.Name,
                    RoleClaimType = ClaimTypes.Role,
                };

                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async context =>
                    {
                        var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<User>>();
                        var userId = context.Principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                        if (!string.IsNullOrEmpty(userId) && Ulid.TryParse(userId, out var userUlid))
                        {
                            var user = await userManager.FindByIdAsync(userId);
                            if (user != null)
                            {
                                var roles = await userManager.GetRolesAsync(user);
                                var identity = context.Principal?.Identity as ClaimsIdentity;

                                if (identity != null)
                                {
                                    foreach (var role in roles)
                                    {
                                        identity.AddClaim(new Claim(ClaimTypes.Role, role));
                                    }
                                }
                            }
                        }
                    },
                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        return context.Response.WriteAsync("{\"error\": \"Unauthorized\"}");
                    }
                };
            });

        services.Configure<DataProtectionTokenProviderOptions>(options =>
            options.TokenLifespan = TimeSpan.FromMinutes(dataProtectionTokenProviderSetting.ExpiresIn));

        services.AddHttpContextAccessor();
        services.AddScoped<IUserContext, UserContext>();
        // Change TokenProvider registration to scoped to match UserManager<User> lifetime
        services.AddScoped<ITokenProvider, TokenProvider>();

        return services;
    }
}
