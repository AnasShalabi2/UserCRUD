using Microsoft.EntityFrameworkCore;
using UserCRUD.Models;

namespace UserCRUD.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=UserDB;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }
    }
}
