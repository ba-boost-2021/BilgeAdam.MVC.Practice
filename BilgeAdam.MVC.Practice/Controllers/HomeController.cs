using BilgeAdam.MVC.Practice.Context;
using BilgeAdam.MVC.Practice.Models;
using BilgeAdam.MVC.Practice.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BilgeAdam.MVC.Practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly NorthwindDbContext dbContext;

        public HomeController(NorthwindDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var result = dbContext.Products.Select(p => new ProductViewDto
            {
                Id = p.ProductID,
                Name = p.ProductName,
                Price = p.UnitPrice,
                Stock = p.UnitsInStock
            }).Take(6).ToList();
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}