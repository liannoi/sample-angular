using System.Collections.Generic;
using System.Linq;
using SampleAngular.Application.Common.Pagings;

namespace SampleAngular.Infrastructure.Common.Paging
{
    public abstract class AbstractPagingViewModel<TEntity> : IPagingViewModel<TEntity>
        where TEntity : class, new()
    {
        private IQueryable<TEntity> _collection;

        public IQueryable<TEntity> Collection
        {
            get => _collection;
            set
            {
                _collection = value;
                PagingDetails.TotalItems = _collection?.Count() ?? 0;
            }
        }

        public IPagingDetails PagingDetails { get; set; }
        public abstract IEnumerable<TEntity> EntitiesPerPage { get; }
    }
}