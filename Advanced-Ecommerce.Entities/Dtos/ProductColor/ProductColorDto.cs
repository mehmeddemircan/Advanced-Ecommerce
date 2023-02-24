using Advanced_Ecommerce.Core.Entity.Abstract;
using Advanced_Ecommerce.Entities.Dtos.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Dtos.ProductColor
{
    public class ProductColorDto  :IDto
    {
        public int Id { get; set; }
        public int ColorId { get; set; }

        public virtual ColorDto Color { get; set; }
    }
}
