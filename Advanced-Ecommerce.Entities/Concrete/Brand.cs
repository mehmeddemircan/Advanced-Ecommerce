using Advanced_Ecommerce.Core.Entity.Concrete;
using Advanced_Ecommerce.Entities.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Concrete
{
    public class Brand : AuditableEntity
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}
