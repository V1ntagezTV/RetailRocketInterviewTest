using Microsoft.EntityFrameworkCore;
using RetailRocketInterviewTest.Models;

namespace RetailRocketInterviewTest
{
    public class ShopContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Offer> Offers { get; set; }
        
        public ShopContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ShopData;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>()
                .HasMany<Offer>(s => s.Offers)
                .WithOne(of => of.Seller);
        }
    }
}