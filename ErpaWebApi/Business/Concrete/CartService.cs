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
    public class CartService : BusinessBase<Cart>, ICartService
    {
        private readonly ICartRepository _repo;

        public CartService(ICartRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
