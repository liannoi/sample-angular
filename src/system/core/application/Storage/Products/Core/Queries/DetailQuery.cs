using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common;
using SampleAngular.Application.Storage.Products.Core.Models;

namespace SampleAngular.Application.Storage.Products.Core.Queries
{
    public class DetailQuery : IRequest<DetailViewModel>
    {
        public int ProductId { get; set; }

        private class Handler : IRequestHandler<DetailQuery, DetailViewModel>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public Handler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DetailViewModel> Handle(DetailQuery request,
                CancellationToken cancellationToken)
            {
                return await _context.Products
                    .Where(e => e.ProductId == request.ProductId)
                    .ProjectTo<DetailViewModel>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
}