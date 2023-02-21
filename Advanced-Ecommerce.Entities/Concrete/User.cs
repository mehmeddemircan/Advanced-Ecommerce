

using Advanced_Ecommerce.Core.Entity.Concrete;

namespace Advanced_Ecommerce.Entities.Concrete
{
    public class User : AuditableEntity
    {

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public bool Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        //Adress can be different out of that 
        public string Address { get; set; }
    }
}
