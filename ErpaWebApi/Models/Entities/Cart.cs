using Infrastructure.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Cart : IEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product? Product { get; set; }
    }
}
