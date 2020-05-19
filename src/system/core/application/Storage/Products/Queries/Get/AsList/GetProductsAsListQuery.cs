using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common.Interfaces;

namespace SampleAngular.Application.Storage.Products.Queries.Get.AsList
{
    public class GetProductsAsListQuery : IRequest<ProductsListViewModel>
    {
        public class GetProductsAsListQueryHandler : IRequestHandler<GetProductsAsListQuery, ProductsListViewModel>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public GetProductsAsListQueryHandler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductsListViewModel> Handle(GetProductsAsListQuery request,
                CancellationToken cancellationToken)
            {
                return new ProductsListViewModel
                {
                    Products = await _context.Products
                        .Take(20)
                        .ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
                };
            }
        }
    }
}