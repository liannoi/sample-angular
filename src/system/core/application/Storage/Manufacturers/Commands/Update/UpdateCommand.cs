using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common.Interfaces;

namespace SampleAngular.Application.Storage.Manufacturers.Commands.Update
{
    public class UpdateCommand : IRequest
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }

        private class Handler : IRequestHandler<UpdateCommand>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;
            private readonly IMediator _mediator;

            public Handler(ISampleAngularContext context, IMapper mapper, IMediator mediator)
            {
                _context = context;
                _mapper = mapper;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(UpdateCommand request,
                CancellationToken cancellationToken)
            {
                var fined = await _context.Manufacturers
                    .Where(e => e.ManufacturerId == request.ManufacturerId)
                    .FirstOrDefaultAsync(cancellationToken);

                fined.Name = request.Name;
                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new ManufacturerUpdated {ManufacturerId = fined.ManufacturerId},
                    cancellationToken);

                return Unit.Value;
            }
        }
    }
}