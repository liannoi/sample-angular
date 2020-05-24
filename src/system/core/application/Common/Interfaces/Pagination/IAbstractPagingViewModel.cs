using System.Collections.Generic;
using System.Linq;

namespace SampleAngular.Application.Common.Interfaces.Pagination
{
    public interface IAbstractPagingViewModel<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> Collection { get; set; }
        IPagingDetails PagingDetails { get; set; }
        IEnumerable<TEntity> EntitiesPerPage { get; }
    }
}