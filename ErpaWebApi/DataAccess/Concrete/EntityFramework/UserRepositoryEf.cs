using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Models.Entities;
using Infrastructure.DataAccess.Concrete.EntityFramework;
using Infrastructure.Model.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class UserRepositoryEf : BaseRepositoryEf<User, DemoContext>, IUserRepository
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (DemoContext ctx = new())
            {
                var result = ctx.OperationClaims
                    .Join(ctx.UserOperationClaims, operationClaim => operationClaim.Id, userOperationClaim => userOperationClaim.OperationClaimId, (operationClaim, userOperationClaim) => new { operationClaim, userOperationClaim })
                    .Where(u => u.userOperationClaim.UserId == user.Id)
                    .Select(u => new OperationClaim { Id = u.operationClaim.Id, Name = u.operationClaim.Name });

                return result.ToList();
            }
        }
    }
}
