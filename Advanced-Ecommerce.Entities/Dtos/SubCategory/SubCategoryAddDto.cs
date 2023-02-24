using Advanced_Ecommerce.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Dtos.SubCategory
{
    public class SubCategoryAddDto : IDto
    {

        public string SubCategoryName { get; set; }

        public int CategoryId { get; set; }
    }
}
