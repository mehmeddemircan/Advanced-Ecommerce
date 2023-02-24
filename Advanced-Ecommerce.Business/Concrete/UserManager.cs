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
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

using Advanced_Ecommerce.Core.Utilities.Responses;
using Advanced_Ecommerce.Core.Utilities.Results;
using Advanced_Ecommerce.Business.Constants;
using AutoMapper;
using System.Linq.Expressions;
using Advanced_Ecommerce.Core.Entity.Concrete.Auth;

namespace Advanced_Ecommerce.Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserRepository _userRepository;
 
        IMapper _mapper; 
        public UserManager(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
           
            _mapper = mapper;   
        }

        public async Task<IDataResult<UserDto>> AddAsync(UserAddDto entity)
        {   

            var user = _mapper.Map<User>(entity);
            //Todo: CreatedTime and CreatedId düzenlenecek  
            user.CreatedDate = DateTime.Now;
            user.CreatedUserId = 1;
            var userAdd = await _userRepository.AddAsync(user);
            var userDto = _mapper.Map<UserDto>(userAdd); 



            return new SuccessDataResult<UserDto>(userDto,Messages.Added); 
        }

       

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {

           var isDelete =  await _userRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete,Messages.Deleted);
        }

        public async Task<IDataResult<UserDto>> GetAsync(Expression<Func<User, bool>> filter)
        {
           var user = await _userRepository.GetAsync(filter);
            if (user !=null)
            {
                var userDto = _mapper.Map<UserDto>(user);
                return new SuccessDataResult<UserDto>(userDto,Messages.Listed);
            }
            return new ErrorDataResult<UserDto>(null,Messages.NotListed);
        }

        public  async Task<IDataResult<UserDto>> GetByIdAsync(int id)
        {
            var user =  await _userRepository.GetAsync(x => x.Id == id);
            if (user !=null)
            {
                var userDto = _mapper.Map<UserDto>(user); 
                return new SuccessDataResult<UserDto>(userDto,Messages.Listed);   
            }
           

            return new ErrorDataResult<UserDto>(null,Messages.NotListed); 
        }

        public async Task<IDataResult<IEnumerable<UserDetailDto>>> GetListAsync(Expression<Func<User, bool>> filter = null)
        {
            if (filter == null)
            {
   
                var response = await _userRepository.GetListAsync();
                var userDetailDtos = _mapper.Map<IEnumerable<UserDetailDto>>(response);
                
                return new SuccessDataResult<IEnumerable<UserDetailDto>>(userDetailDtos,Messages.Listed);
            }
            else
            {
                var response = await _userRepository.GetListAsync(filter);
                var userDetailDtos = _mapper.Map<IEnumerable<UserDetailDto>>(response);

                return new SuccessDataResult<IEnumerable<UserDetailDto>>(userDetailDtos, Messages.Listed);
            }
         
            
        }

      

        public async Task<IDataResult<UserUpdateDto>> UpdateAsync(UserUpdateDto entity)
        {
           var getUser = await _userRepository.GetAsync((x => x.Id == entity.Id));
            var user = _mapper.Map<User>(entity);
            user.CreatedDate = getUser.CreatedDate;
            user.CreatedUserId = getUser.CreatedUserId;
            user.UpdatedDate = DateTime.Now;
            user.UpdatedUserId = 1;
   

            var resultUpdate = await _userRepository.UpdateAsync(user);
            var userUpdateMap = _mapper.Map<UserUpdateDto>(resultUpdate);
        
            return new SuccessDataResult<UserUpdateDto>(userUpdateMap,Messages.Updated); 
        }

    

        public List<OperationClaim> GetClaims(User user)
        {
            return _userRepository.GetClaims(user);
        }

        public void Add(User user)
        {
            _userRepository.AddAsync(user);
        }

        public User GetByMail(string email)
        {
            return _userRepository.Get(u => u.Email == email);
        }
    }
}
