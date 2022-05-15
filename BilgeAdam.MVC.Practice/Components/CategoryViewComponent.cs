using BilgeAdam.Data;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdam.MVC.Practice.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly NorthwindDbContext dbContext;

        public CategoryViewComponent(NorthwindDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            var result = dbContext.Categories.ToList();
            return View(result);
        }
    }
}