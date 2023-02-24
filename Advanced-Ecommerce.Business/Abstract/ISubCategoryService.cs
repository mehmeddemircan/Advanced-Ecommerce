using Advanced_Ecommerce.Core.Utilities.Responses;
using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Abstract
{
    public interface ISubCategoryService
    {
        Task<IDataResult<IEnumerable<SubCategoryDetailDto>>> GetListAsync(Expression<Func<SubCategory, bool>> filter = null);

        Task<IDataResult<SubCategoryDto>> AddAsync(SubCategoryAddDto entity);


        Task<IDataResult<SubCategoryUpdateDto>> UpdateAsync(SubCategoryUpdateDto entity);

        Task<IDataResult<SubCategoryDto>> GetAsync(Expression<Func<SubCategory, bool>> filter);

        Task<IDataResult<bool>> DeleteAsync(int id);

    }
}
