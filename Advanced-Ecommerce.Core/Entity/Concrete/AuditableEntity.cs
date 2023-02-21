

using Advanced_Ecommerce.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.Core.Entity.Concrete
{
    public class AuditableEntity : BaseEntity, ICreatedEntity, IUpdatedEntity
    {

        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get  ; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }


    }
}
