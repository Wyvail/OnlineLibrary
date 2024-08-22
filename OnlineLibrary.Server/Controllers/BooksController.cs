using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using OnlineLibrary.Server.Data;
using OnlineLibrary.Server.Models;
using OnlineLibrary.Server.Models.Entities;

namespace OnlineLibrary.Server.Controllers
{
    // localhost:xxxx/api/books
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext bookDbContext;

        public BooksController(ApplicationDbContext bookDbContext)
        {
            this.bookDbContext = bookDbContext;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var randomBooks = bookDbContext.Books.ToList();

            randomBooks.OrderBy(r => EF.Functions.Random()).Take(10);

            return Ok(randomBooks);
        }

        [HttpPost]
        public IActionResult AddBook(string title, AddBookDto addBookDto)
        {
            var book = bookDbContext.Books.FirstOrDefault(b => b.Title == title);
            if (book is null)
            {
                var bookEntity = new Book()
                {
                    Title = addBookDto.Title,
                    Author = addBookDto.Author,
                    Description = addBookDto.Description,
                    ImageId = addBookDto.ImageId,
                    Publisher = addBookDto.Publisher,
                    PublishDate = addBookDto.PublishDate,
                    Category = addBookDto.Category,
                    ISBN = addBookDto.ISBN,
                    PageCount = addBookDto.PageCount,
                    Available = addBookDto.Available,
                    CheckOutDate = addBookDto.CheckOutDate,
                    ReturnDate = addBookDto.ReturnDate
                };


                bookDbContext.Books.Add(bookEntity);
                bookDbContext.SaveChanges();

                return Ok(bookEntity);
            }
            else return Ok(book);
        }

        [HttpPut]
        public IActionResult UpdateBook(string title, UpdateBookDto updateBookDto)
        {
            var book = bookDbContext.Books.FirstOrDefault(b => b.Title == title);
            if (book is null)
            {
                return NotFound();
            }

            book.Title = updateBookDto.Title;
            book.Author = updateBookDto.Author;
            book.Description = updateBookDto.Description;
            book.ImageId = updateBookDto.ImageId;
            book.Publisher = updateBookDto.Publisher;
            book.PublishDate = updateBookDto.PublishDate;
            book.Category = updateBookDto.Category;
            book.ISBN = updateBookDto.ISBN;
            book.PageCount = updateBookDto.PageCount;

            bookDbContext.SaveChanges();
            return Ok(book);
        }

        [HttpPut]
        [Route("updateBookAvailability")]
        public IActionResult UpdateBookAvailability(string title, UpdateAvailabilityDto updateAvailabilityDto)
        {
            var book = bookDbContext.Books.FirstOrDefault(b => b.Title == title);
            if (book is null)
            {
                return NotFound();
            }

            book.Available = updateAvailabilityDto.Available;
            book.CheckOutDate = updateAvailabilityDto.CheckOutDate;
            book.ReturnDate = updateAvailabilityDto.ReturnDate;

            bookDbContext.SaveChanges();
            return Ok(book);
        }

        [HttpDelete]
        public IActionResult DeleteBook(string title)
        {
            var book = bookDbContext.Books.FirstOrDefault(b => b.Title == title);
            if (book is null)
            {
                return NotFound();
            }

            bookDbContext.Books.Remove(book);
            bookDbContext.SaveChanges();
            return Ok();
        }
    }
}
