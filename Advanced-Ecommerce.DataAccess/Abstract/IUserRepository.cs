using Advanced_Ecommerce.Core.DataAccess;
using Advanced_Ecommerce.Core.Entity.Concrete.Auth;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.DataAccess.Abstract
{
    public interface IUserRepository : IBaseRepository<User>
    {
        List<OperationClaim> GetClaims(User user);

    }
}
