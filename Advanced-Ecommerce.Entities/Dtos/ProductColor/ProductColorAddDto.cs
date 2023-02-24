using Advanced_Ecommerce.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Dtos.ProductColor
{
    public class ProductColorAddDto :IDto
    {

        public int ProductId { get; set; }

        public int ColorId { get; set; }
    }
}
