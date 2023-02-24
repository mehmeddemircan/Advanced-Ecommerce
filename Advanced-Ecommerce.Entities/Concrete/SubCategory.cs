using Advanced_Ecommerce.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Concrete
{
    public class SubCategory : AuditableEntity
    {

        public string SubCategoryName { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
