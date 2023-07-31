using Infrastructure.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Product : IEntity
    {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int Desi { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
    }
}
