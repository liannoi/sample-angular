using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common.Interfaces;

namespace SampleAngular.Application.Storage.Manufacturers.Queries.Get.AsList
{
    public class GetManufacturersAsListQuery : IRequest<ManufacturersListViewModel>
    {
        public class
            GetManufacturersAsListQueryHandler : IRequestHandler<GetManufacturersAsListQuery, ManufacturersListViewModel
            >
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public GetManufacturersAsListQueryHandler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ManufacturersListViewModel> Handle(GetManufacturersAsListQuery request,
                CancellationToken cancellationToken)
            {
                return new ManufacturersListViewModel
                {
                    Manufacturers = await _context.Manufacturers
                        .ProjectTo<ManufacturerLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
                };
            }
        }
    }
}