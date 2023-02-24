using Advanced_Ecommerce.Core.Entity.Abstract;
using Advanced_Ecommerce.Entities.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Dtos.Brand
{
    // tek marka gösteren dto 
    public class BrandDto : IDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<ProductDetailDto> Products { get; set; }
    }
}
