using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common.Interfaces;

namespace SampleAngular.Application.Storage.Manufacturers.Queries.Get
{
    public class GetManufacturerQuery : IRequest<ManufacturerLookupDto>
    {
        public int ManufacturerId { get; set; }

        public class GetManufacturerQueryHandler : IRequestHandler<GetManufacturerQuery, ManufacturerLookupDto>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public GetManufacturerQueryHandler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ManufacturerLookupDto> Handle(GetManufacturerQuery request,
                CancellationToken cancellationToken)
            {
                return await _context.Manufacturers
                    .Where(e => e.ManufacturerId == request.ManufacturerId)
                    .ProjectTo<ManufacturerLookupDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
}