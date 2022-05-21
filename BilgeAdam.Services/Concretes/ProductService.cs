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
            if (entity is not null)
            {
                dbContext.Products.Remove(entity);
            }
            var result = dbContext.SaveChanges();
            return result>0;
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

        public ProductViewDto GetProductById(int id)
        {
            return dbContext.Products.Where(p => p.ProductID == id).Select(x => new ProductViewDto
            {
                Id = x.ProductID,
                Name = x.ProductName,
                Price = x.UnitPrice == null ? 0 : x.UnitPrice.Value,
                Stock = x.UnitsInStock == null ? 0 : x.UnitsInStock.Value,
                Discontinued = x.Discontinued
            }).SingleOrDefault();
        }

        public bool UpdateProduct(ProductUpdateInput input)
        {
            var conflict = dbContext.Products.FirstOrDefault(x => x.ProductName.ToLower() == input.Name.ToLower() && x.ProductID != input.Id);
            if(conflict is not null)
            {
                return false;
            }
            var entity = dbContext.Products.SingleOrDefault(x => x.ProductID == input.Id);
            if(entity is null)
            {
                return false;
            }
            entity.UnitPrice = input.Price;
            entity.UnitsInStock = input.Stock;
            entity.ProductName = input.Name;
            entity.Discontinued = input.Discontinued;
            dbContext.Update(entity);
            return dbContext.SaveChanges() > 0;
        }
    }
}