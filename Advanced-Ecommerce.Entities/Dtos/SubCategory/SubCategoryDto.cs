using Advanced_Ecommerce.Core.Entity.Abstract;
using Advanced_Ecommerce.Entities.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Dtos.SubCategory
{
    public class SubCategoryDto : IDto
    {

        public int Id { get; set; }

        public string SubCategoryName { get; set; }

        public int CategoryId { get; set; }

        public virtual CategoryDetailDto Category { get; set; }
    }
}
