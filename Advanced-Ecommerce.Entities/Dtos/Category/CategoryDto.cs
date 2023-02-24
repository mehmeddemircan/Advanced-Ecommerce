using Advanced_Ecommerce.Core.Entity.Abstract;
using Advanced_Ecommerce.Entities.Dtos.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Dtos.Category
{
    public class CategoryDto : IDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual IEnumerable<SubCategoryDetailDto> SubCategories { get; set; }

    }
}
