using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess.Utilities.Results
{
   public class SuccessfullDataResult<T> : DataResult<T>
    {
        public SuccessfullDataResult(T data, string message):base(data,true,message)
        {

        }
        public SuccessfullDataResult(T data):base(data,true)
        {

        }
        public SuccessfullDataResult(string message) : base( true, message)
        {

        }
    }
}
