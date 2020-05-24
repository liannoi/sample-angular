using System.Collections.Generic;
using System.Linq;
using SampleAngular.Application.Storage.Manufacturers;
using SampleAngular.Infrastructure.Common.Pagination;

namespace SampleAngular.Infrastructure.Pagination
{
    public class ManufacturersPagingViewModel : AbstractPagingViewModel<ManufacturerLookupDto>
    {
        public override IEnumerable<ManufacturerLookupDto> EntitiesPerPage => Collection.OrderBy(e => e.Name)
            .Skip((PagingDetails.CurrentPage - 1) * PagingDetails.ItemsPerPage)
            .Take(PagingDetails.ItemsPerPage);
    }
}