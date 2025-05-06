using Microsoft.EntityFrameworkCore;
using ShopApp.Core.Entities;

namespace ShopApp.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.Products)
                .WithOne(product => product.User)
                .HasForeignKey(product => product.Id);
        }
    }
}
