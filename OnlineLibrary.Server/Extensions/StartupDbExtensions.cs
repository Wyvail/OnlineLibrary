using OnlineLibrary.Server.Data;

namespace OnlineLibrary.Server.Extensions
{
    public static class StartupDbExtensions
    {
        public static async void CreateDbIfNotExists(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var applicationContext = services.GetRequiredService<ApplicationDbContext>();

            applicationContext.Database.EnsureCreated();



            DbInitializerSeedBooks.InitializeDatabase(applicationContext);
        }
    }
}
