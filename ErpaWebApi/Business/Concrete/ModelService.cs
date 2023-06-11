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
    public class ModelService : BusinessBase<Model>, IModelService
    {
        private readonly IModelRepository _repo;

        public ModelService(IModelRepository repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
