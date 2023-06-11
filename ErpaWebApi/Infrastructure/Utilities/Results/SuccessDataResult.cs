using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities.Results
{
    public class SuccessDataResult<TEntity> : DataResult<TEntity>
    {
        public SuccessDataResult(TEntity data, string message) : base(data, success: true, message)
        {
        }
        public SuccessDataResult(TEntity data) : base(data, success: true)
        {

        }

        public SuccessDataResult(string message) : base(default, success: true, message)
        {

        }
        public SuccessDataResult() : base(default, success: true)
        {

        }
    }
}
