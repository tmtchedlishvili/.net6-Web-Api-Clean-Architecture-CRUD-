using Infrastructure.DB;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ApplicationBuilderExtensions
{
    /// <summary>
    ///     Create Identity DB if not exist
    /// </summary>
    /// <param name="builder"></param>
    public static void EnsureIdentityDbIsCreated(this IApplicationBuilder builder)
    {
        using (var serviceScope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var services = serviceScope.ServiceProvider;

            var dbContext = services.GetRequiredService<ApplicationDbContext>();

            // Ensure the database is created.
            // Note this does not use migrations. If database may be updated using migrations, use DbContext.Database.Migrate() instead.
            dbContext.Database.EnsureCreated();
        }
    }

    /// <summary>
    ///     Seed Identity data
    /// </summary>
    /// <param name="builder"></param>
    public static async Task SeedIdentityDataAsync(this IApplicationBuilder builder)
    {
        using (var serviceScope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var services = serviceScope.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            await Infrastructure.Identity.Seed.ApplicationDbContextDataSeed.SeedAsync(userManager, roleManager);
        }
    }
}