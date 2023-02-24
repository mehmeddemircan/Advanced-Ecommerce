using Advanced_Ecommerce.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Dtos.SubCategory
{
    public class SubCategoryDetailDto : IDto
    {

        public int Id { get; set; }

        public string SubCategoryName { get; set; }

      

    }
}
