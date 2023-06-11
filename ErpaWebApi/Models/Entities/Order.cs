using Infrastructure.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Order : IEntity
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
