using EFCore.AutomaticMigrations;
using OnlineLibrary.Server.Data;

namespace OnlineLibrary.Server.Extensions
{
    public static class StartupDbExtensions
    {
        public static void CreateBookDbIfNotExists(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var applicationContext = services.GetRequiredService<ApplicationDbContext>();

            applicationContext.Database.EnsureCreated();

            applicationContext.MigrateToLatestVersion();

            DbInitializerSeedBooks.InitializeDatabase(applicationContext);
        }

        public static void CreateLibrariansDbIfNotExists(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var userDbContext = services.GetRequiredService<UserDbContext>();

            userDbContext.Database.EnsureCreated();

            userDbContext.MigrateToLatestVersion();

            DbInitializerSeedLibrarians.InitializeDatabase(userDbContext);
        }
    }
}
