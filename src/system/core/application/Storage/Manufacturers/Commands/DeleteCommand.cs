using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common;

namespace SampleAngular.Application.Storage.Manufacturers.Commands
{
    public class DeleteCommand : IRequest
    {
        public int ManufacturerId { get; set; }

        private class Handler : IRequestHandler<DeleteCommand>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public Handler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                var fined = await _context.Manufacturers
                    .Where(e => e.ManufacturerId == request.ManufacturerId)
                    .FirstOrDefaultAsync(cancellationToken);

                _context.Manufacturers.Remove(fined);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
                // return _mapper.Map<ManufacturerLookupDto>(fined);
            }
        }
    }
}