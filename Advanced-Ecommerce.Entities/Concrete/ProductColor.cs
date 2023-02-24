using Advanced_Ecommerce.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Concrete
{
    public class ProductColor : AuditableEntity
    {

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int ColorId { get; set; }

        public virtual Color Color { get; set; }



    }
}
