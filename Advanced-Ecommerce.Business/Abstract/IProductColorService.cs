using Advanced_Ecommerce.Core.Utilities.Responses;
using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.Product;
using Advanced_Ecommerce.Entities.Dtos.ProductColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Abstract
{
    public interface IProductColorService
    {

        Task<IDataResult<ProductColorDto>> AddColorToProduct(ProductColorAddDto productColorAddDto);

        Task<IDataResult<IEnumerable<ProductColorDto>>> GetProductColorListAsync(Expression<Func<ProductColor, bool>> filter = null);

        Task<IDataResult<bool>> DeleteProductColorAsync(int id);
    }
}
