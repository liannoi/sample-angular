using System.Collections.Generic;
using System.Linq;
using SampleAngular.Application.Storage.Manufacturers.Models;
using SampleAngular.Infrastructure.Common.Paging;

namespace SampleAngular.Infrastructure.Paging
{
    public class ManufacturerPagingViewModel : AbstractPagingViewModel<DetailViewModel>
    {
        public override IEnumerable<DetailViewModel> EntitiesPerPage => Collection.OrderBy(e => e.Name)
            .Skip((PagingDetails.CurrentPage - 1) * PagingDetails.ItemsPerPage)
            .Take(PagingDetails.ItemsPerPage);
    }
}