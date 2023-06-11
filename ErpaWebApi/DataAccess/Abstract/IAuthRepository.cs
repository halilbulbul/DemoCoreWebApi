using Models.Entities;
using Infrastructure.DataAccess.Abstract;
using Infrastructure.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAuthRepository : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
