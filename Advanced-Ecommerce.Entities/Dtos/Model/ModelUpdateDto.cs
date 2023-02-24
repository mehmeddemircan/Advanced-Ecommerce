using Advanced_Ecommerce.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Dtos.Model
{
    public class ModelUpdateDto : IDto
    {

        public int Id { get; set; }

        public string ModelName { get; set; }
    }
}
