﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities.Results
{
    public class ErrorDataResult<TEntity> : DataResult<TEntity>
    {
        public ErrorDataResult(TEntity data, string message) : base(data, success: false, message)
        {
        }
        public ErrorDataResult(TEntity data) : base(data, success: false)
        {

        }

        public ErrorDataResult(string message) : base(default, success: false, message)
        {

        }
        public ErrorDataResult() : base(default, success: false)
        {

        }
    }
}
