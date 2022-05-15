using BilgeAdam.Common.Dtos;
using BilgeAdam.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdam.MVC.Practice.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService productService;

        public AdminController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductAddDto input)
        {
            
            if (ModelState.IsValid)
            {
                productService.Add(input);
                return RedirectToAction("Product");
            }
            return View(input);

        }
    }
}
