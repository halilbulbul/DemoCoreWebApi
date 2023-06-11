using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities.Results
{
    public interface IDataResult<TEntity> : IResult
    {
        TEntity Data { get; }
    }
}
