using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common;

namespace SampleAngular.Application.Storage.Manufacturers.Commands
{
    public class UpdateCommand : IRequest
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }

        private class Handler : IRequestHandler<UpdateCommand>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public Handler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateCommand request,
                CancellationToken cancellationToken)
            {
                var fined = await _context.Manufacturers
                    .Where(e => e.ManufacturerId == request.ManufacturerId)
                    .FirstOrDefaultAsync(cancellationToken);

                fined.Name = request.Name;
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
                // return _mapper.Map<ManufacturerLookupDto>(fined);
            }
        }
    }
}