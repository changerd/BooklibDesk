using BooklibDesk.Models;
using Microsoft.EntityFrameworkCore;

namespace BooklibDesk.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=booklib;Username=postgres;Password=123");
        }

        public DbSet<Book> Books { get; set; }
    }
}
