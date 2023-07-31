using Infrastructure.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Business.Abstract
{
    public interface ICategoryService : IBusinessBase<Category>
    {
    }
}
