using BilgeAdam.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilgeAdam.Data
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<OrderDetail>().HasOne(p => p.Product).WithMany(o => o.OrderDetails).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //}
    }
}