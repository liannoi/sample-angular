using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common;
using SampleAngular.Application.Storage.Products.Photos.Models;

namespace SampleAngular.Application.Storage.Products.Photos.Queries
{
    public class DetailQuery : IRequest<ListViewModel>
    {
        public int ProductId { get; set; }

        private class Handler : IRequestHandler<ListQuery.ByProduct, ListViewModel>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public Handler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ListViewModel> Handle(ListQuery.ByProduct request, CancellationToken cancellationToken)
            {
                return new ListViewModel
                {
                    ProductPhotos = await _context.ProductPhotos
                        .Where(e => e.ProductId == request.ProductId)
                        .ProjectTo<ProductPhotoDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
                };
            }
        }
    }
}