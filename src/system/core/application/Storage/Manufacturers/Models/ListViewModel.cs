using System.Collections.Generic;
using SampleAngular.Application.Common.Pagings;

namespace SampleAngular.Application.Storage.Manufacturers.Models
{
    public class ListViewModel
    {
        public IPagingDetails Pagination { get; set; }
        public IList<DetailViewModel> Manufacturers { get; set; }
    }
}