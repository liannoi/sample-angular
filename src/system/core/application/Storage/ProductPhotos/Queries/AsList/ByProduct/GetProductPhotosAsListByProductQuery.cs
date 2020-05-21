using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common.Interfaces;

namespace SampleAngular.Application.Storage.ProductPhotos.Queries.AsList.ByProduct
{
    public class GetProductPhotosAsListByProductQuery : IRequest<ProductPhotosListViewModel>
    {
        public int ProductId { get; set; }

        public class GetProductPhotosAsListQueryHandler :
            IRequestHandler<GetProductPhotosAsListByProductQuery, ProductPhotosListViewModel>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public GetProductPhotosAsListQueryHandler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductPhotosListViewModel> Handle(GetProductPhotosAsListByProductQuery request,
                CancellationToken cancellationToken)
            {
                return new ProductPhotosListViewModel
                {
                    ProductPhotos = await _context.ProductPhotos
                        .Where(e => e.ProductId == request.ProductId)
                        .ProjectTo<ProductPhotoLookupDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
                };
            }
        }
    }
}