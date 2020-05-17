using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common.Interfaces;

namespace SampleAngular.Application.Storage.Manufacturers.Commands.Delete
{
    public class DeleteManufacturerCommand : IRequest<ManufacturerLookupDto>
    {
        public int ManufacturerId { get; set; }

        public class
            DeleteManufacturerCommandHandler : IRequestHandler<DeleteManufacturerCommand, ManufacturerLookupDto>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public DeleteManufacturerCommandHandler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ManufacturerLookupDto> Handle(DeleteManufacturerCommand request,
                CancellationToken cancellationToken)
            {
                var fined = await _context.Manufacturers
                    .Where(e => e.ManufacturerId == request.ManufacturerId)
                    .FirstOrDefaultAsync(cancellationToken);

                _context.Manufacturers.Remove(fined);
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ManufacturerLookupDto>(fined);
            }
        }
    }
}