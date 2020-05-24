using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SampleAngular.Application.Common.Interfaces;
using SampleAngular.Application.Common.Interfaces.Pagination;

namespace SampleAngular.Application.Storage.Products.Queries.Get.AsList
{
    public class GetProductsAsListQuery : IRequest<ProductsListViewModel>
    {
        public IAbstractPagingViewModel<ProductLookupDto> Info { get; set; }

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
                request.Info.Collection = _context.Products.ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider);

                return new ProductsListViewModel
                    {Pagination = request.Info.PagingDetails, Products = request.Info.EntitiesPerPage.ToList()};
            }
        }
    }
}