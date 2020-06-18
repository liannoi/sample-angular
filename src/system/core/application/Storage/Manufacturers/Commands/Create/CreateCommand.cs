using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SampleAngular.Application.Common.Interfaces;
using SampleAngular.Domain.Entities;

namespace SampleAngular.Application.Storage.Manufacturers.Commands.Create
{
    public class CreateCommand : IRequest
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }

        private class Handler : IRequestHandler<CreateCommand>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public Handler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CreateCommand request,
                CancellationToken cancellationToken)
            {
                var result = await _context.Manufacturers
                    .AddAsync(new Manufacturer {Name = request.Name}, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
                // return _mapper.Map<ManufacturerLookupDto>(result.Entity);
            }
        }
    }
}