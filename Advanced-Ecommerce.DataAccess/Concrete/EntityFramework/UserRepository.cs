

using Advanced_Ecommerce.Core.Entity.Concrete.Auth;
using Advanced_Ecommerce.DataAccess.Abstract;
using Advanced_Ecommerce.DataAccess.Concrete.Contexts;
using Advanced_Ecommerce.DataAccess.EntityFramework;
using Advanced_Ecommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Ecommerce.DataAccess.Concrete.EntityFramework
{
    public class UserRepository : EfBaseRepository<User, ApplicationDbContext>, IUserRepository
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ApplicationDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
