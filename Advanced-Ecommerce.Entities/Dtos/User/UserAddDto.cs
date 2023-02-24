

using Advanced_Ecommerce.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Dtos.UserDtos
{
    public class UserAddDto : IDto
    {

  
        public string UserName { get; set; }

        public string Password { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        //Adress can be different out of that 
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

   



    }
}
