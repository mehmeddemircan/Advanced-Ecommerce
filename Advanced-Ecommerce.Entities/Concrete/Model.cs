using Advanced_Ecommerce.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Concrete
{
    public class Model : AuditableEntity
    {

        public string ModelName { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}
