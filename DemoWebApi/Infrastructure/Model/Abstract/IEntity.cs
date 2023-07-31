using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Abstract
{
    public class IEntity
    {
        public int Id { get; set; }
        public bool State { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime RemoveDate { get; set; }
    }
}
