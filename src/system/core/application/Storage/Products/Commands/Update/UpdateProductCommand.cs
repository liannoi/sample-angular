using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common.Interfaces;
using SampleAngular.Application.Storage.Manufacturers;
using SampleAngular.Domain.Entities;

namespace SampleAngular.Application.Storage.Products.Commands.Update
{
    public class UpdateProductCommand : IRequest<ProductLookupDto>
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public ManufacturerLookupDto Manufacturer { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductLookupDto>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public UpdateProductCommandHandler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductLookupDto> Handle(UpdateProductCommand request,
                CancellationToken cancellationToken)
            {
                var fined = await _context.Products
                    .Where(e => e.ProductId == request.ProductId)
                    .FirstOrDefaultAsync(cancellationToken);

                fined.Manufacturer = _mapper.Map<Manufacturer>(request.Manufacturer);
                fined.Name = request.Name;
                fined.ProductNumber = request.ProductNumber;
                _context.Products.Update(fined);
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ProductLookupDto>(fined);
            }
        }
    }
}