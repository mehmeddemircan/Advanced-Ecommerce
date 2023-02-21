using Advanced_Ecommerce.Business.Abstract;
using Advanced_Ecommerce.DataAccess.Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Advanced_Ecommerce.Entities.Dtos.UserDtos;
using Advanced_Ecommerce.Entities.Concrete;

namespace Advanced_Ecommerce.Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> AddAsync(UserAddDto entity)
        {

            User user = new User()
            {
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Address = entity.Address,
                //Todo:CreatedDate ve CreatedUserId düzenlenecek
                CreatedDate = DateTime.Now,
                Email = entity.Email,
                DateOfBirth = entity.DateOfBirth,
                Gender = entity.Gender,
                UserName = entity.UserName,
                Password = entity.Password,
                CreatedUserId = 1,

            };

            var userAdd = await _userRepository.AddAsync(user);

            UserDto userDto = new UserDto()
            {
                LastName = userAdd.LastName,
                FirstName = userAdd.FirstName,
                Address = userAdd.Address,

                Email = userAdd.Email,
                DateOfBirth = userAdd.DateOfBirth,
                Gender = userAdd.Gender,
                UserName = userAdd.UserName,
                Id = userAdd.Id

            };
            return userDto; 
        }

        public async Task<bool> DeleteAsync(int id)
        {

            return await _userRepository.DeleteAsync(id); 
        }

        public  async Task<UserDto> GetByIdAsync(int id)
        {
            var user =  await _userRepository.GetAsync(x => x.Id == id);
            if (user !=null)
            {
                UserDto userDto = new UserDto()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth,
                    Address = user.Address,
                    Email = user.Email,
                    Gender = user.Gender,
                    UserName = user.UserName,

                };
                return userDto;   
            }
           

            return null; 
        }

        public async Task<IEnumerable<UserDetailDto>> GetListAsync()
        {   

            List<UserDetailDto> userDetailDtos = new List<UserDetailDto>(); 
            var response = await _userRepository.GetListAsync();
            foreach (var item in response.ToList())
            {
                userDetailDtos.Add(new UserDetailDto()
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Gender = item.Gender == true ? "Erkek" : "Kadın ",
                    DateOfBirth = item.DateOfBirth,
                    UserName = item.UserName,
                    Address = item.Address,
                    Email = item.Email,
                    Id = item.Id

                });
            
            }
            return userDetailDtos;
        }

        public async Task<UserUpdateDto> UpdateAsync(UserUpdateDto entity)
        {
           var getUser = await _userRepository.GetAsync((x => x.Id == entity.Id));

            User user = new User()
            {
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Address = entity.Address,

                Email = entity.Email,
                DateOfBirth = entity.DateOfBirth,
                Gender = entity.Gender,
                UserName = entity.UserName,
                Id = entity.Id,
                CreatedDate = getUser.CreatedDate,
                CreatedUserId = getUser.CreatedUserId,
                Password = entity.Password,
                UpdatedDate = DateTime.Now,
                UpdatedUserId = 1 , 


            };

            var userUpdate = await _userRepository.UpdateAsync(user);

            UserUpdateDto userUpdateDto = new UserUpdateDto()
            {
                LastName = userUpdate.LastName,
                FirstName = userUpdate.FirstName,
                Address = userUpdate.Address,

                Email = userUpdate.Email,
                DateOfBirth = userUpdate.DateOfBirth,
                Gender = userUpdate.Gender,
                UserName = userUpdate.UserName,
                Id = userUpdate.Id,

                Password = userUpdate.Password,

            };
            return userUpdateDto; 
        }
    }
}
