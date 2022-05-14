using BilgeAdam.MVC.Practice.Context;
using BilgeAdam.MVC.Practice.Models;
using BilgeAdam.MVC.Practice.Models.Dtos;
using BilgeAdam.MVC.Practice.Models.Entities;
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

        public IActionResult Index(Category category)
        {
            var result = new List<ProductViewDto>();
            if (category.CategoryID != 0)
            {
                result = dbContext.Products.OrderByDescending(x => x.ProductID).Where(x => x.CategoryID == category.CategoryID).Select(p => new ProductViewDto
                {
                    Id = p.ProductID,
                    Name = p.ProductName,
                    Price = p.UnitPrice == null ? 0 : p.UnitPrice.Value,
                    Stock = p.UnitsInStock == null ? 0 : p.UnitsInStock.Value,
                }).Take(6).ToList();
            }
            else
            {
                result = dbContext.Products.OrderByDescending(x=>x.ProductID).Select(p => new ProductViewDto
                {
                    Id = p.ProductID,
                    Name = p.ProductName,
                    Price = p.UnitPrice == null ? 0 : p.UnitPrice.Value,
                    Stock = p.UnitsInStock == null ? 0 : p.UnitsInStock.Value,
                }).Take(6).ToList();
            }
            ViewBag.title = category.CategoryName;
            return View(result);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var result = dbContext.Products.Where(p => p.ProductID == id).Select(p => new ProductDetailDto
            {
                Id = p.ProductID,
                CategoryName = p.Category.CategoryName,
                CompanyName = p.Supplier.CompanyName,
                Name = p.ProductName,
                Order = p.UnitsOnOrder == null ? 0 : p.UnitsOnOrder.Value,
                Price = p.UnitPrice == null ? 0 : p.UnitPrice.Value,
                Quantity = p.QuantityPerUnit,
                Stock = p.UnitsInStock == null ? 0 : p.UnitsInStock.Value,
                SupplierContactName = p.Supplier.ContactName
            }).FirstOrDefault();
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductAddDto input)
        {
            if (ModelState.IsValid)
            {
                dbContext.Products.Add(new Product
                {
                    CategoryID = 1,
                    Discontinued = true,
                    ProductName = input.Name,
                    QuantityPerUnit = "Deneme",
                    SupplierID = 1,
                    UnitPrice = input.Price,
                    UnitsInStock = input.Stock
                });
                dbContext.SaveChanges();
                return Redirect("Index");
            }
            return View(input);
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}