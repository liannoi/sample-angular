using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common.Interfaces;

namespace SampleAngular.Application.Storage.Manufacturers.Commands.Update
{
    public class UpdateManufacturerCommand : IRequest<ManufacturerLookupDto>
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }

        public class
            UpdateManufacturerCommandHandler : IRequestHandler<UpdateManufacturerCommand, ManufacturerLookupDto>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public UpdateManufacturerCommandHandler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ManufacturerLookupDto> Handle(UpdateManufacturerCommand request,
                CancellationToken cancellationToken)
            {
                var fined = await _context.Manufacturers
                    .Where(e => e.ManufacturerId == request.ManufacturerId)
                    .FirstOrDefaultAsync(cancellationToken);

                fined.Name = request.Name;
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ManufacturerLookupDto>(fined);
            }
        }
    }
}