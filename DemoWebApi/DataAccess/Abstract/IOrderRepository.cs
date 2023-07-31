using Infrastructure.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace DataAccess.Abstract
{
    public interface IOrderRepository : IEntityRepository<Order>
    {
    }
}
