

using Advanced_Ecommerce.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Core.Entity.Concrete
{
    public class BaseEntity : IEntity
    {
        public int Id { get ; set; }
    }
}
