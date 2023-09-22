using System;
using System.Collections.Generic;
using System.Text;

namespace UPS.Service.Result
{
    /// <summary>
    /// Paged list interface
    /// </summary>
    public interface IPagedListResult
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        int TotalPages { get; set; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}
