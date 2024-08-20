namespace OnlineLibrary.Server.Data
{
    public static class DbInitializerSeedBooks
    {
        public static void InitializeDatabase(ApplicationDbContext applicationDbContext)
        {
            if (applicationDbContext.Books.Any())
                return;
        }
    }
}
