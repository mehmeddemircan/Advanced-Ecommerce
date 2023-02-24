using Advanced_Ecommerce.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Concrete
{
    public class Product : AuditableEntity
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }


        public int ModelId { get; set; }

        public virtual Model Model { get; set; }
        public virtual IEnumerable<ProductColor> ProductColors { get; set; }
    }
}
