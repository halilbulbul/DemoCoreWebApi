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
    public class AuthRepositoryEf : BaseRepositoryEf<User, DemoContext>, IAuthRepository
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (DemoContext ctx = new())
            {
                //var result = from operationClaim in ctx.OperationClaims
                //             join userOperationClaim in ctx.UserOperationClaims on operationClaim.Id equals userOperationClaim.OperationClaimId
                //             where userOperationClaim.UserId == user.Id
                //             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                var result = ctx.OperationClaims
                    .Join(ctx.UserOperationClaims, oc => oc.Id, oc => oc.OperationClaimId, (operationClaim, userOperationClaim) => new { operationClaim, userOperationClaim })
                    .Where(x => x.userOperationClaim.UserId == user.Id)
                    .Select(x => new OperationClaim { Id = x.operationClaim.Id, Name = x.operationClaim.Name });

                return result.ToList();
            }
        }
    }
}
