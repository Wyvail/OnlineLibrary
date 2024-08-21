using OnlineLibrary.Server.Models.Entities;

namespace OnlineLibrary.Server.Data
{
    public static class DbInitializerSeedLibrarians
    {
        public static void InitializeDatabase(UserDbContext userDbContext)
        {
            if (userDbContext.LibrarianStatuses.Any())
                return;

            var librarianStatusOne = new LibrarianStatus
            {
                Email = "admin@admin.net",
                IsLibrarian = true
            };

            userDbContext.LibrarianStatuses.Add(librarianStatusOne);
            userDbContext.SaveChanges();
        }
    }
    
}
