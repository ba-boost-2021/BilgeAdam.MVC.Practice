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
    }
}