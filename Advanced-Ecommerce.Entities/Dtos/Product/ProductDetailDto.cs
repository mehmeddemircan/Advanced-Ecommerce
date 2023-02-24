using Advanced_Ecommerce.Core.Entity.Abstract;
using Advanced_Ecommerce.Entities.Dtos.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Dtos.Product
{   

    //butun ürünleri listeleyen dto 
    public class ProductDetailDto  : IDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int BrandId { get; set; }

        public int ModelId { get; set; }

        public int SubCategoryId { get; set; }
    }
}
