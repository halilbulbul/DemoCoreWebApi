using Infrastructure.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Model : IEntity
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
    }
}
