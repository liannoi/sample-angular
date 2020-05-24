using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SampleAngular.Application.Common.Interfaces;
using SampleAngular.Application.Common.Interfaces.Pagination;

namespace SampleAngular.Application.Storage.Manufacturers.Queries.Get.AsList
{
    public class GetManufacturersAsListQuery : IRequest<ManufacturersListViewModel>
    {
        public IAbstractPagingViewModel<ManufacturerLookupDto> Info { get; set; }

        public class GetManufacturersAsListQueryHandler :
            IRequestHandler<GetManufacturersAsListQuery, ManufacturersListViewModel>
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
                request.Info.Collection =
                    _context.Manufacturers.ProjectTo<ManufacturerLookupDto>(_mapper.ConfigurationProvider);

                return new ManufacturersListViewModel
                    {Pagination = request.Info.PagingDetails, Manufacturers = request.Info.EntitiesPerPage.ToList()};
            }
        }
    }
}