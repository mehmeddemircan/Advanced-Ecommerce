using Advanced_Ecommerce.Core.DataAccess;
using Advanced_Ecommerce.Core.Utilities.Responses;
using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.Product;
using Advanced_Ecommerce.Entities.Dtos.ProductColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.DataAccess.Abstract
{
    public interface IProductRepository : IBaseRepository<Product>
    {

        Task<ProductDto> AddColorToProduct(ProductColorAddDto productColorAddDto);
    }
}
