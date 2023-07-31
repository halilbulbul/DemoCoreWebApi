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
    public class BrandService : BusinessBase<Brand>, IBrandService
    {
        private readonly IBrandRepository _repo;

        public BrandService(IBrandRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
