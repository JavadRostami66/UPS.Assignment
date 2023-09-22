using System;
using System.Collections.Generic;
using System.Text;

namespace UPS.Service.Result
{
    public class Result:IResult
    {
        public int Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
