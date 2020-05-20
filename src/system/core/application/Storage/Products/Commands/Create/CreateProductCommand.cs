using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SampleAngular.Application.Common.Interfaces;
using SampleAngular.Application.Storage.Manufacturers;
using SampleAngular.Domain.Entities;

namespace SampleAngular.Application.Storage.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<ProductLookupDto>
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public ManufacturerLookupDto Manufacturer { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductLookupDto>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductLookupDto> Handle(CreateProductCommand request,
                CancellationToken cancellationToken)
            {
                var result = await _context.Products.AddAsync(new Product
                {
                    ManufacturerId = request.Manufacturer.ManufacturerId,
                    Name = request.Name,
                    ProductNumber = request.ProductNumber
                }, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ProductLookupDto>(result.Entity);
            }
        }
    }
}