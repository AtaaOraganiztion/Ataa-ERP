using Infrastructure.Database.Seeders;
using Web.Api.Permissions;

namespace Web.Api.Extensions;

public static class DataSeederExtensions
{
    public static async Task SeedDatabaseAsync(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        IdentitiesDataSeeder identitiesDataSeeder = scope.ServiceProvider.GetRequiredService<IdentitiesDataSeeder>();
        await identitiesDataSeeder.SeedAsync(PermissionsHelper.GetAll());
    }
}