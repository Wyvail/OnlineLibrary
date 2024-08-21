using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Server.Models.Entities;

namespace OnlineLibrary.Server.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<LibrarianStatus> LibrarianStatuses { get; set; }
    }
}
