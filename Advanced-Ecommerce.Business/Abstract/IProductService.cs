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
    public interface IProductService
    {

        Task<IDataResult<IEnumerable<ProductDetailDto>>> GetListAsync(Expression<Func<Product, bool>> filter = null);

        Task<IDataResult<ProductDto>> AddAsync(ProductAddDto entity);


        Task<IDataResult<ProductUpdateDto>> UpdateAsync(ProductUpdateDto entity);

        Task<IDataResult<ProductDto>> GetAsync(Expression<Func<Product, bool>> filter);

        Task<IDataResult<bool>> DeleteAsync(int id);





    }
}
