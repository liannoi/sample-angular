using System.Collections.Generic;
using System.Linq;
using SampleAngular.Application.Storage.Products;
using SampleAngular.Infrastructure.Common.Pagination;

namespace SampleAngular.Infrastructure.Pagination
{
    public class ProductsPagingViewModel : AbstractPagingViewModel<ProductLookupDto>
    {
        public override IEnumerable<ProductLookupDto> EntitiesPerPage => Collection.OrderBy(e => e.Name)
            .Skip((PagingDetails.CurrentPage - 1) * PagingDetails.ItemsPerPage)
            .Take(PagingDetails.ItemsPerPage);
    }
}