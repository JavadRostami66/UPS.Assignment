using System;
using System.Collections.Generic;
using System.Text;

namespace UPS.Service.Result
{
    public class ListResult<T> : Result, IListResult<T>
    {
        public List<T> DataList { get; set; }
        public int TotalCount => DataList.Count;
    }
}
