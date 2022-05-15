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
            var result = productService.GetAllProduct();
            return View(result);
        }
        public IActionResult DeleteProduct(int id)
        {
            productService.Delete(id);
            return RedirectToAction("Product");
        }

        [HttpPost]
        public IActionResult Product(ProductAddDto input)
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
