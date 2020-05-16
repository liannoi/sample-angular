using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common.Interfaces;

namespace SampleAngular.Application.Storage.Products.Queries.Get
{
    public class GetProductQuery : IRequest<ProductLookupDto>
    {
        public int ProductId { get; set; }

        public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductLookupDto>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public GetProductQueryHandler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductLookupDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                return await _context.Products
                    .Where(e => e.ProductId == request.ProductId)
                    .ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
}