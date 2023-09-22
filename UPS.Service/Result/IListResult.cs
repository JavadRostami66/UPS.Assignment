using System;
using System.Collections.Generic;
using System.Text;

namespace UPS.Service.Result
{
    interface IListResult<T>
    {
        List<T> DataList { get; set; }
        int TotalCount { get;}
    }
}
