using Advanced_Ecommerce.Core.Entity.Abstract;
using Advanced_Ecommerce.Entities.Dtos.Brand;
using Advanced_Ecommerce.Entities.Dtos.Category;
using Advanced_Ecommerce.Entities.Dtos.Model;
using Advanced_Ecommerce.Entities.Dtos.ProductColor;
using Advanced_Ecommerce.Entities.Dtos.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Dtos.Product
{

    //tek ürün gösteren  dto 
    public class ProductDto : IDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int BrandId { get; set; }

        public virtual BrandDetailDto Brand { get; set; }

        public int SubCategoryId { get; set; }

        public virtual SubCategoryDto SubCategory { get; set; }

        public int ModelId { get; set; }

        public virtual ModelDetailDto Model { get; set; }
        public virtual ICollection<ProductColorDto> ProductColors  { get; set; }
    }
}
