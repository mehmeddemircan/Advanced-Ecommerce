using Advanced_Ecommerce.Core.Entity.Concrete.Auth;
using Advanced_Ecommerce.Core.Utilities.Responses;
using Advanced_Ecommerce.Core.Utilities.Security.JWT;
using Advanced_Ecommerce.Entities.Dtos.Auth;
using Advanced_Ecommerce.Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
