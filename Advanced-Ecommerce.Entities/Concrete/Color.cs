using Advanced_Ecommerce.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Concrete
{
    public class Color : AuditableEntity
    {

        public string ColorName { get; set; }

        public string HexaDecimalCode { get; set; }

        public virtual IEnumerable<ProductColor> ProductColors { get; set; }
    }
}
