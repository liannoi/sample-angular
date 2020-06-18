using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common;
using SampleAngular.Application.Storage.Manufacturers.Models;

namespace SampleAngular.Application.Storage.Manufacturers.Queries
{
    public class DetailQuery : IRequest<DetailViewModel>
    {
        public int ManufacturerId { get; set; }

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
                return await _context.Manufacturers
                    .Where(man => man.ManufacturerId == request.ManufacturerId)
                    .ProjectTo<DetailViewModel>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
}