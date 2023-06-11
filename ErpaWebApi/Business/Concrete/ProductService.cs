using Infrastructure.Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Models.Entities;

namespace Business.Concrete
{
    public class ProductService : BusinessBase<Product>, IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public bool StockControl(int ProductId)
        {
            var p = _repo.Get(x => x.Id == ProductId);
            if (p.Data.Stock > 0)
                return true;
            else return false;
        }
    }
}
