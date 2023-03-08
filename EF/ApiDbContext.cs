using Microsoft.EntityFrameworkCore;

namespace AspNetAPI.EF
{
    public class ApiDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./ApiDb.db");
        }

        public DbSet<Entites.Product> Products { get; set; }
    }
}
