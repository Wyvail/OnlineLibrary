using OnlineLibrary.Server.Models.Entities;

namespace OnlineLibrary.Server.Data
{
    public static class DbInitializerSeedBooks
    {
        public static void InitializeDatabase(ApplicationDbContext applicationDbContext)
        {
            if (applicationDbContext.Books.Any())
                return;

            var bookOne = new Book
            {
                Author = "Author One",
                Title = "Title One",
                Description = "Description One",
                ImageId = 1,
                Publisher = "Publisher One",
                PublishDate = new DateOnly(2021, 1, 1),
                Category = "Category One",
                ISBN = 1234567890,
                PageCount = 100,
                Available = true
            };

            var bookTwo = new Book
            {
                Author = "Author Two",
                Title = "Title Two",
                Description = "Description Two",
                ImageId = 2,
                Publisher = "Publisher Two",
                PublishDate = new DateOnly(2021, 2, 2),
                Category = "Category Two",
                ISBN = 1234567891,
                PageCount = 200,
                Available = true
            };

            applicationDbContext.Books.Add(bookOne);
            applicationDbContext.Books.Add(bookTwo);

            applicationDbContext.SaveChanges();
        }
    }
}
