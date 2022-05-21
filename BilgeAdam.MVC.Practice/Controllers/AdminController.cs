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
        [HttpGet]
        public IActionResult GetProductById([FromRoute]int id)
        {
            var result = productService.GetProductById(id);
            if(result is not null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductUpdateInput input)
        {
            var result = productService.UpdateProduct(input);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
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
