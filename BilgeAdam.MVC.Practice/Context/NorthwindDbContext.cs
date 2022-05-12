using BilgeAdam.MVC.Practice.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilgeAdam.MVC.Practice.Context
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}