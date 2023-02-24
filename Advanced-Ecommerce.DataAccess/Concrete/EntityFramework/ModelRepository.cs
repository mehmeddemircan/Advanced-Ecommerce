using Advanced_Ecommerce.DataAccess.Abstract;
using Advanced_Ecommerce.DataAccess.Concrete.Contexts;
using Advanced_Ecommerce.DataAccess.EntityFramework;
using Advanced_Ecommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.DataAccess.Concrete.EntityFramework
{
    public class ModelRepository : EfBaseRepository<Model,ApplicationDbContext>, IModelRepository
    {
    }
}
