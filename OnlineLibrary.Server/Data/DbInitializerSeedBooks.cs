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

            var bookThree = new Book
            {
                Author = "J. R. R. Tolkien",
                Title = "The Lord of the Rings: The Return of the King",
                Description = "The hobbit and his companions make their way to the final battle.",
                ImageId = 2,
                Publisher = "Houghton Mifflin",
                PublishDate = "1955-10-20",
                Category = "Fantasy",
                ISBN = 0345339738,
                PageCount = 624,
                Available = true,
                CheckOutDate = "1990-03-03",
                ReturnDate = "1990-03-04"
            };

            var bookFour = new Book
            {
                Author = "J. R. R. Tolkien",
                Title = "The Hobbit",
                Description = "A hobbit is swept into an adventure with dwarves and a wizard.",
                ImageId = 3,
                Publisher = "Houghton Mifflin",
                PublishDate = "1937-09-21",
                Category = "Fantasy",
                ISBN = 0345339681,
                PageCount = 310,
                Available = true,
                CheckOutDate = "1990-04-04",
                ReturnDate = "1990-04-05"
            };

            var bookFive = new Book
            {
                Author = "J. R. R. Tolkien",
                Title = "The Silmarillion",
                Description = "The history of Middle Earth.",
                ImageId = 4,
                Publisher = "Houghton Mifflin",
                PublishDate = "1977-09-15",
                Category = "Fantasy",
                ISBN = 0345325818,
                PageCount = 365,
                Available = true,
                CheckOutDate = "1990-05-05",
                ReturnDate = "1990-05-06"
            };

            var bookSix = new Book
            {
                Author = "J. R. R. Tolkien",
                Title = "Unfinished Tales",
                Description = "A collection of stories from Middle Earth.",
                ImageId = 5,
                Publisher = "Houghton Mifflin",
                PublishDate = "1980-09-01",
                Category = "Fantasy",
                ISBN = 0345296053,
                PageCount = 472,
                Available = true,
                CheckOutDate = "1990-06-06",
                ReturnDate = "1990-06-07"
            };

            var bookSeven = new Book
            {
                Author = "J. R. R. Tolkien",
                Title = "The Children of Hurin",
                Description = "The story of Turin Turambar.",
                ImageId = 6,
                Publisher = "Houghton Mifflin",
                PublishDate = "2007-04-17",
                Category = "Fantasy",
                ISBN = 0345518845,
                PageCount = 313,
                Available = true,
                CheckOutDate = "1990-07-07",
                ReturnDate = "1990-07-08"
            };

            var bookEight = new Book
            {
                Author = "J. R. R. Tolkien",
                Title = "The Fall of Gondolin",
                Description = "The story of the fall of the hidden city of Gondolin.",
                ImageId = 7,
                Publisher = "Houghton Mifflin",
                PublishDate = "2018-08-30",
                Category = "Fantasy",
                ISBN = 1328613044,
                PageCount = 304,
                Available = true,
                CheckOutDate = "1990-08-08",
                ReturnDate = "1990-08-09"
            };

            var bookNine = new Book
            {
                Author = "J. R. R. Tolkien",
                Title = "The History of Middle Earth",
                Description = "A collection of the history of Middle Earth.",
                ImageId = 8,
                Publisher = "Houghton Mifflin",
                PublishDate = "1983-09-01",
                Category = "Fantasy",
                ISBN = 0345468399,
                PageCount = 472,
                Available = true,
                CheckOutDate = "1990-09-09",
                ReturnDate = "1990-09-10"
            };

            var bookTen = new Book
            {
                Author = "J. R. R. Tolkien",
                Title = "The Adventures of Tom Bombadil",
                Description = "A collection of poems from Middle Earth.",
                ImageId = 9,
                Publisher = "Houghton Mifflin",
                PublishDate = "1962-11-14",
                Category = "Fantasy",
                ISBN = 0395083805,
                PageCount = 64,
                Available = true,
                CheckOutDate = "1990-10-10",
                ReturnDate = "1990-10-11"
            };

            var bookEleven = new Book
            {
                Author = "Stephen King",
                Title = "The Shining",
                Description = "A family is trapped in a haunted hotel.",
                ImageId = 10,
                Publisher = "Doubleday",
                PublishDate = "1977-01-28",
                Category = "Horror",
                ISBN = 0385121679,
                PageCount = 447,
                Available = true,
                CheckOutDate = "1990-11-11",
                ReturnDate = "1990-11-12"
            };

            var bookTwelve = new Book
            {
                Author = "Stephen King",
                Title = "It",
                Description = "A group of friends battle an evil entity.",
                ImageId = 11,
                Publisher = "Viking",
                PublishDate = "1986-09-15",
                Category = "Horror",
                ISBN = 0670813028,
                PageCount = 1138,
                Available = true,
                CheckOutDate = "1990-12-12",
                ReturnDate = "1990-12-13"
            };

            var bookThirteen = new Book
            {
                Author = "Stephen King",
                Title = "The Dark Tower: The Gunslinger",
                Description = "The first book in the Dark Tower series.",
                ImageId = 12,
                Publisher = "Grant",
                PublishDate = "1982-06-10",
                Category = "Fantasy",
                ISBN = 0452284694,
                PageCount = 224,
                Available = true,
                CheckOutDate = "1991-01-01",
                ReturnDate = "1991-01-02"
            };
            
            var bookFourteen = new Book
            {
                Author = "Stephen King",
                Title = "The Dark Tower: The Drawing of the Three",
                Description = "The second book in the Dark Tower series.",
                ImageId = 13,
                Publisher = "Grant",
                PublishDate = "1987-05-01",
                Category = "Fantasy",
                ISBN = 0452284694,
                PageCount = 400,
                Available = true,
                CheckOutDate = "1991-02-02",
                ReturnDate = "1991-02-03"
            };

            var bookFifteen = new Book
            {
                Author = "Stephen King",
                Title = "The Dark Tower: The Waste Lands",
                Description = "The third book in the Dark Tower series.",
                ImageId = 14,
                Publisher = "Grant",
                PublishDate = "1991-08-27",
                Category = "Fantasy",
                ISBN = 0452284694,
                PageCount = 422,
                Available = true,
                CheckOutDate = "1991-03-03",
                ReturnDate = "1991-03-04"
            };

            var bookSixteen = new Book
            {
                Author = "George Orwell",
                Title = "1984",
                Description = "A dystopian society where Big Brother is always watching.",
                ImageId = 15,
                Publisher = "Secker & Warburg",
                PublishDate = "1949-06-08",
                Category = "Dystopian",
                ISBN = 0451524934,
                PageCount = 328,
                Available = true,
                CheckOutDate = "1991-04-04",
                ReturnDate = "1991-04-05"
            };

            var bookSeventeen = new Book
            {
                Author = "George Orwell",
                Title = "Animal Farm",
                Description = "A farm where the animals take over.",
                ImageId = 16,
                Publisher = "Secker & Warburg",
                PublishDate = "1945-08-17",
                Category = "Dystopian",
                ISBN = 0451524934,
                PageCount = 112,
                Available = true,
                CheckOutDate = "1991-05-05",
                ReturnDate = "1991-05-06"
            };

            var bookEighteen = new Book
            { 
                Author = "F. Scott Fitzgerald",
                Title = "The Great Gatsby",
                Description = "The roaring '20s set the stage for a tragic love story.",
                ImageId = 17,
                Publisher = "Charles Scribner's Sons",
                PublishDate = "1925-04-10",
                Category = "Romance",
                ISBN = 0743273567,
                PageCount = 180,
                Available = true,
                CheckOutDate = "1991-06-06",
                ReturnDate = "1991-06-07"
            };

            var bookNineteen = new Book
            { 
                Author = "Harper Lee",
                Title = "To Kill a Mockingbird",
                Description = "A young black man is accused of a crime he didn't commit.",
                ImageId = 18,
                Publisher = "J. B. Lippincott & Co.",
                PublishDate = "1960-07-11",
                Category = "Fiction",
                ISBN = 0060935464,
                PageCount = 281,
                Available = true,
                CheckOutDate = "1991-07-07",
                ReturnDate = "1991-07-08"
            };

            var bookTwenty = new Book
            {
                Author = "Naoki Urasawa",
                Title = "Pluto: Urasawa x Tezuka, Vol. 1",
                Description = "A detective must solve a series of unnatural murders.",
                ImageId = 19,
                Publisher = "Shogakukan",
                PublishDate = "2003-09-05",
                Category = "Mystery",
                ISBN = 1421519180,
                PageCount = 200,
                Available = true,
                CheckOutDate = "1991-08-08",
                ReturnDate = "1991-08-09"
            };

            applicationDbContext.Books.Add(bookOne);
            applicationDbContext.Books.Add(bookTwo);
            applicationDbContext.Books.Add(bookThree);
            applicationDbContext.Books.Add(bookFour);
            applicationDbContext.Books.Add(bookFive);
            applicationDbContext.Books.Add(bookSix);
            applicationDbContext.Books.Add(bookSeven);
            applicationDbContext.Books.Add(bookEight);
            applicationDbContext.Books.Add(bookNine);
            applicationDbContext.Books.Add(bookTen);
            applicationDbContext.Books.Add(bookEleven);
            applicationDbContext.Books.Add(bookTwelve);
            applicationDbContext.Books.Add(bookThirteen);
            applicationDbContext.Books.Add(bookFourteen);
            applicationDbContext.Books.Add(bookFifteen);
            applicationDbContext.Books.Add(bookSixteen);
            applicationDbContext.Books.Add(bookSeventeen);
            applicationDbContext.Books.Add(bookEighteen);
            applicationDbContext.Books.Add(bookNineteen);
            applicationDbContext.Books.Add(bookTwenty);


            applicationDbContext.SaveChanges();
        }
    }
}
