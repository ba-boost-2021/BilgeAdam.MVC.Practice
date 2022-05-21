using BilgeAdam.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Services.Abstractions
{
    public interface IProductService
    {
        void Add(ProductAddDto dto);
        List<ProductViewDto> GetAllProduct();
        bool Delete(int id);
        ProductViewDto GetProductById(int id);
        bool UpdateProduct(ProductUpdateInput input);
    }
}
