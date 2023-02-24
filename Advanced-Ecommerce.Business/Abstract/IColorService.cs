using Advanced_Ecommerce.Core.Utilities.Responses;
using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Abstract
{
    public interface IColorService
    {
        Task<IDataResult<IEnumerable<ColorDetailDto>>> GetListAsync(Expression<Func<Color, bool>> filter = null);

        Task<IDataResult<ColorDto>> AddAsync(ColorAddDto entity);


        Task<IDataResult<ColorUpdateDto>> UpdateAsync(ColorUpdateDto entity);

        Task<IDataResult<ColorDto>> GetAsync(Expression<Func<Brand, bool>> filter);

        Task<IDataResult<bool>> DeleteAsync(int id);

    }
}
