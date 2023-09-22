using System;
using System.Collections.Generic;
using System.Text;

namespace UPS.Service.Result
{
    public class MessageResult<T> : Result
    {
        public T Entity { get; set; }
    }
}
