using Advanced_Ecommerce.Core.Utilities.Responses;
using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Abstract
{
    public interface IModelService
    {

        Task<IDataResult<IEnumerable<ModelDetailDto>>> GetListAsync(Expression<Func<Model, bool>> filter = null);

        Task<IDataResult<ModelDto>> AddAsync(ModelAddDto entity);


        Task<IDataResult<ModelUpdateDto>> UpdateAsync(ModelUpdateDto entity);

        Task<IDataResult<ModelDto>> GetAsync(Expression<Func<Model, bool>> filter);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
