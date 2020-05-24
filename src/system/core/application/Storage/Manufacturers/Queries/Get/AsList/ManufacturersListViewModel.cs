using System.Collections.Generic;
using SampleAngular.Application.Common.Interfaces.Pagination;

namespace SampleAngular.Application.Storage.Manufacturers.Queries.Get.AsList
{
    public class ManufacturersListViewModel
    {
        public IPagingDetails Pagination { get; set; }
        public IList<ManufacturerLookupDto> Manufacturers { get; set; }
    }
}