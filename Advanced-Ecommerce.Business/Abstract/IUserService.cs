using Advanced_Ecommerce.Core.Entity.Concrete.Auth;
using Advanced_Ecommerce.Core.Utilities.Responses;

using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Abstract
{
    public interface IUserService 
    {
        Task<IDataResult<IEnumerable<UserDetailDto>>> GetListAsync(Expression<Func<User, bool>> filter = null);
        Task<IDataResult<UserDto>> GetByIdAsync(int id);
        Task<IDataResult<UserDto>> GetAsync(Expression<Func<User, bool>> filter );

        //Task<IDataResult<UserDto>> AddAsync(UserAddDto entity);

        Task<IDataResult<UserUpdateDto>> UpdateAsync(UserUpdateDto entity);

        Task<IDataResult<bool>> DeleteAsync(int id);

        //Task<IDataResult<AccessToken>> Authenticate(UserForLoginDto userForLoginDto); 

        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);

    }
}
