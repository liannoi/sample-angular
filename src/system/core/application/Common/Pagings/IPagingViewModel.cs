using System.Collections.Generic;
using System.Linq;

namespace SampleAngular.Application.Common.Pagings
{
    public interface IPagingViewModel<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> Collection { get; set; }
        IPagingDetails PagingDetails { get; set; }
        IEnumerable<TEntity> EntitiesPerPage { get; }
    }
}