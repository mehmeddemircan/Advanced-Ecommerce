using Advanced_Ecommerce.Core.Utilities.Responses;
using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Abstract
{
    public interface ICategoryService
    {

        Task<IDataResult<IEnumerable<CategoryDetailDto>>> GetListAsync(Expression<Func<Category, bool>> filter = null);

        Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto entity);


        Task<IDataResult<CategoryUpdateDto>> UpdateAsync(CategoryUpdateDto entity);

        Task<IDataResult<CategoryDto>> GetAsync(Expression<Func<Category, bool>> filter);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
