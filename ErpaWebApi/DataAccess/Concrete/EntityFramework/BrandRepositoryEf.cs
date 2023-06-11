using Infrastructure.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Models.Entities;

namespace DataAccess.Concrete.EntityFramework
{
    public class BrandRepositoryEf : BaseRepositoryEf<Brand, DemoContext>, IBrandRepository
    {
    }
}
