using Advanced_Ecommerce.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Dtos.Brand
{
    public class BrandUpdateDto  : IDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
