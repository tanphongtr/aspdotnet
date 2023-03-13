using Microsoft.EntityFrameworkCore;
using AspNetAPI.Entites;

namespace AspNetAPI.EF
{
    public class ApiDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./ApiDb.db");
        }

        public  DbSet<Product>? Products { get; set; }
        public  DbSet<Category>? Categories { get; set; }
    }

    // 
}
