using Infrastructure.Business.Concrete;
using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Models.Entities;

namespace Business.Concrete
{
    public class CategoryService : BusinessBase<Category>, ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
