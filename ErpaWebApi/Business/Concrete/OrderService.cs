using Business.Abstract;
using DataAccess.Abstract;
using Infrastructure.Business.Concrete;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderService : BusinessBase<Order>, IOrderService
    {
        private readonly IOrderRepository _repo;

        public OrderService(IOrderRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
