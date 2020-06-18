using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SampleAngular.Application.Common.Interfaces;
using SampleAngular.Application.Common.Pagings;
using SampleAngular.Application.Storage.Manufacturers.Models;

namespace SampleAngular.Application.Storage.Manufacturers.Queries
{
    public class ListQuery : IRequest<ListViewModel>
    {
        public IPagingViewModel<DetailViewModel> Info { get; set; }

        private class Handler : IRequestHandler<ListQuery, ListViewModel>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public Handler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ListViewModel> Handle(ListQuery request,
                CancellationToken cancellationToken)
            {
                request.Info.Collection = _context.Manufacturers
                    .ProjectTo<DetailViewModel>(_mapper.ConfigurationProvider);

                return new ListViewModel
                    {Pagination = request.Info.PagingDetails, Manufacturers = request.Info.EntitiesPerPage.ToList()};
            }
        }
    }
}