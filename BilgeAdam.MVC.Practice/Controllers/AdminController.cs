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
        [HttpDelete]
        public IActionResult DeleteProduct([FromRoute]int id)
        {
            var result = productService.Delete(id);
            if (result)
            {
                return Json(result);
            }
            else
            {
                return BadRequest("Başarısız");
            }
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
