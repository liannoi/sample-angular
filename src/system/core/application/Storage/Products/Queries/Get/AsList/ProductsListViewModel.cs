using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using SampleAngular.Application.Common.Interfaces.Pagination;

namespace SampleAngular.Application.Storage.Products.Queries.Get.AsList
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class ProductsListViewModel
    {
        public IPagingDetails Pagination { get; set; }
        public IList<ProductLookupDto> Products { get; set; }
    }
}