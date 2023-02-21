
using Advanced_Ecommerce.Core.Entity.Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Dtos.UserDtos
{   

    //müsteriye göstermek için
    public class UserDetailDto : IDto
    {

        public int Id { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        //Adress can be different out of that 
        public string Address { get; set; }



    }
}
