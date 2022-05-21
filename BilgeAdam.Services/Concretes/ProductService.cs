using BilgeAdam.Common.Dtos;
using BilgeAdam.Data;
using BilgeAdam.Data.Entities;
using BilgeAdam.Services.Abstractions;

namespace BilgeAdam.Services.Concretes
{
    internal class ProductService : IProductService
    {
        private readonly NorthwindDbContext dbContext;

        public ProductService(NorthwindDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(ProductAddDto dto)
        {
            dbContext.Products.Add(new Product
            {
                CategoryID = 1,
                Discontinued = true,
                ProductName = dto.Name,
                QuantityPerUnit = "Deneme",
                SupplierID = 1,
                UnitPrice = dto.Price,
                UnitsInStock = dto.Stock
            });
            dbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var entity = dbContext.Products.SingleOrDefault(x => x.ProductID == id);
            if(entity is not null)
            {
                dbContext.Products.Remove(entity);
            }
            var result = dbContext.SaveChanges();
            return false;
        }

        public List<ProductViewDto> GetAllProduct()
        {
            return dbContext.Products.OrderByDescending(p => p.ProductID).Select(p => new ProductViewDto
            {
                Id = p.ProductID,
                Name = p.ProductName,
                Price = p.UnitPrice == null ? 0 : p.UnitPrice.Value,
                Stock = p.UnitsInStock == null ? 0 : p.UnitsInStock.Value
            }).Take(10).ToList();
        }
    }
}