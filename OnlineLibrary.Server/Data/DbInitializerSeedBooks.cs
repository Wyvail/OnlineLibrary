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
                Author = "J. R. R. Tolkien",
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Description = "One hobbit departs on a journey to cast the One Ring into the fire.",
                ImageId = 0,
                Publisher = "Houghton Mifflin",
                PublishDate = "1954-10-21",
                Category = "Fantasy",
                ISBN = 0345339703,
                PageCount = 480,
                Available = true,
                CheckOutDate = "1990-01-01",
                ReturnDate = "1990-01-02"
            };

            var bookTwo = new Book
            {
                Author = "J. R. R. Tolkien",
                Title = "The Lord of the Rings: The Two Towers",
                Description = "Having made their way through the treacherous mines, new allies and old appear to help the hobbit on his journey.",
                ImageId = 1,
                Publisher = "Houghton Mifflin",
                PublishDate = "1955-04-21",
                Category = "Fantasy",
                ISBN = 0345339711,
                PageCount = 416,
                Available = true,
                CheckOutDate = "1990-02-02",
                ReturnDate = "1990-02-03"
            };


            applicationDbContext.Books.Add(bookOne);
            applicationDbContext.Books.Add(bookTwo);

            applicationDbContext.SaveChanges();
        }
    }
}
