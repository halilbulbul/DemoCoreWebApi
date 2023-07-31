using Infrastructure.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Category : IEntity
    {
        [ForeignKey("ParentCategory")]
        public int? ParentId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
