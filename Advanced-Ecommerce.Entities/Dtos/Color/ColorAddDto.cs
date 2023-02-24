using Advanced_Ecommerce.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Entities.Dtos.Color
{
    public class ColorAddDto : IDto
    {

        public string ColorName { get; set; }

        public string HexaDecimalCode { get; set; }
    }
}
