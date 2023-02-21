using Advanced_Ecommerce.Entities.Concrete;
using Advanced_Ecommerce.Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Abstract
{
    public interface IUserService 
    {
        Task<IEnumerable<UserDetailDto>> GetListAsync();
        Task<UserDto> GetByIdAsync(int id);

        Task<UserDto> AddAsync(UserAddDto entity);

        Task<UserUpdateDto> UpdateAsync(UserUpdateDto entity);

        Task<bool> DeleteAsync(int id);

    }
}
