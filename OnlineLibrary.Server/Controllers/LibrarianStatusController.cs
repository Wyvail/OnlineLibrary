using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Server.Data;

namespace OnlineLibrary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrarianStatusController : ControllerBase
    {
        private readonly UserDbContext dbContext;
        public LibrarianStatusController(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetLibrarianStatus(string email)
        {
            var status = from s in dbContext.LibrarianStatuses
                         where s.Email == email
                         select s.IsLibrarian;
            var firstStatus = status.First();
            return Ok(firstStatus);
        }
    }
}
