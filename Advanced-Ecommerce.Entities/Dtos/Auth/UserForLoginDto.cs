using Advanced_Ecommerce.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Dtos.Auth
{
    public class UserForLoginDto : IDto
    {

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
