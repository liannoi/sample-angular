using System;
using SampleAngular.Application.Common.Interfaces.Pagination;

namespace SampleAngular.Infrastructure.Common.Pagination
{
    public class PagingDetails : IPagingDetails
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int) Math.Ceiling((decimal) TotalItems / ItemsPerPage);
    }
}