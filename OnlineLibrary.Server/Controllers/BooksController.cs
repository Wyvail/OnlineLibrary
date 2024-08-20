using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var allBooks = bookDbContext.Books.ToList();

            return Ok(allBooks);
        }

        [HttpPost]
        public IActionResult AddBook(AddBookDto addBookDto)
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
            };


            bookDbContext.Books.Add(bookEntity);
            bookDbContext.SaveChanges();

            return Ok(bookEntity);
        }

        
        
    }
}
