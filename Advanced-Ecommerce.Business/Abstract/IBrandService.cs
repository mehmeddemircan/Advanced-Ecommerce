using Advanced_Ecommerce.Core.Utilities.Responses;
using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Abstract
{
    public interface IBrandService
    {

        Task<IDataResult<IEnumerable<BrandDetailDto>>> GetListAsync(Expression<Func<Brand, bool>> filter = null);

        Task<IDataResult<BrandDto>> AddAsync(BrandAddDto entity);


        Task<IDataResult<BrandUpdateDto>> UpdateAsync(BrandUpdateDto entity);

        Task<IDataResult<BrandDto>> GetAsync(Expression<Func<Brand, bool>> filter);

        Task<IDataResult<bool>> DeleteAsync(int id);


    }
}
