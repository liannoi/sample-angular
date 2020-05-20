using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common.Interfaces;
using SampleAngular.Application.Storage.Products.Models;

namespace SampleAngular.Application.Storage.Products.Queries.Get.AsList
{
    public class GetProductsAsListByFilterQuery : IRequest<ProductsListViewModel>
    {
        public GetProductsAsListByFilterQuery()
        {
            FilteredManufacturers = new List<FilterManufacturer>();
        }

        public string FilteredName { get; set; }
        public IEnumerable<FilterManufacturer> FilteredManufacturers { get; set; }

        private Expression<Func<ProductLookupDto, bool>> ProcessPredicate()
        {
            var predicate = PredicateBuilder.New<ProductLookupDto>(true);
            if (!string.IsNullOrEmpty(FilteredName))
                predicate = predicate.And(product => product.Name.Contains(FilteredName));

            if (!FilteredManufacturers.Select(c => c.IsChecked).Any()) return predicate;
            {
                var predicateManufacturer = PredicateBuilder.New<ProductLookupDto>(true);
                predicateManufacturer = FilteredManufacturers
                    .Where(item => item.IsChecked)
                    .Aggregate(predicateManufacturer,
                        (current, item) => current.Or(c => c.Manufacturer.ManufacturerId == item.ManufacturerId));

                predicate = predicate.And(predicateManufacturer);
            }

            return predicate;
        }

        public class GetProductsAsListByFilterQueryHandler :
            IRequestHandler<GetProductsAsListByFilterQuery, ProductsListViewModel>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public GetProductsAsListByFilterQueryHandler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductsListViewModel> Handle(GetProductsAsListByFilterQuery request,
                CancellationToken cancellationToken)
            {
                return new ProductsListViewModel
                {
                    Products = await _context.Products
                        .Take(15)
                        .ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider)
                        .Where(request.ProcessPredicate())
                        .ToListAsync(cancellationToken)
                };
            }
        }
    }
}