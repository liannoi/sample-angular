using System.Collections.Generic;
using SampleAngular.Application.Common.Pagings;

namespace SampleAngular.Application.Storage.Products.Core.Models
{
    public class ListViewModel
    {
        public IPagingDetails Pagination { get; set; }
        public IList<DetailViewModel> Products { get; set; }
    }
}