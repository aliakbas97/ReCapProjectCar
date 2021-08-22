using Core.DataAccess.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess.Utilities.Results
{
   public interface IDataResult<T> :IResult
    {
        T Data { get; }
    }
}
