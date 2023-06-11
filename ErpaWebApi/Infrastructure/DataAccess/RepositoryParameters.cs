using Infrastructure.Model.Abstract;
using Infrastructure.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public class RepositoryParameters<TEntity>
        where TEntity : IEntity, new()
    {
        public Expression<Func<TEntity, bool>> filter { get; set; } = null;
        public int take { get; set; } = 0;
        public int skip { get; set; } = 0;
        public string[] includeList { get; set; } = null;
        public Expression<Func<TEntity, object>> orderBy { get; set; } = null;
        public SortDirection? sortDirection { get; set; } = null;

    }
}
