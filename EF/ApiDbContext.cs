using Microsoft.EntityFrameworkCore;
using AspNetAPI.Entites;

namespace AspNetAPI.EF
{
    public class ApiDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlite("Filename=./ApiDb.db");

            // write code using the optionsBuilder to configure the database using mysql

            optionsBuilder.UseMySql("server=localhost;database=test12;user=root;password=amBc7juC;port=4612", new MySqlServerVersion(new Version(8, 0, 25)));
        }

        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // modelBuilder.Entity<Product>()
            //     .HasOne(p => p.User)
            //     .WithOne(u => u.Product)
            //     .HasForeignKey<User>(user => user.Id);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Product)
                .WithOne(p => p.User)
                .HasForeignKey<Product>(p => p.UserId);
        }
    }
}
