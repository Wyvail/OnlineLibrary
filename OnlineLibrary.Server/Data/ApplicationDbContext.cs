using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Server.Models.Entities;

namespace OnlineLibrary.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
