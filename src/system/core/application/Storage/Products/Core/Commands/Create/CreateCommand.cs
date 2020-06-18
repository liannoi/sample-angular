using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SampleAngular.Application.Common.Interfaces;
using SampleAngular.Application.Storage.Manufacturers.Models;
using SampleAngular.Application.Storage.Products.Photos.Models;
using SampleAngular.Domain.Entities;

namespace SampleAngular.Application.Storage.Products.Core.Commands.Create
{
    public class CreateCommand : IRequest
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public ManufacturerDto Manufacturer { get; set; }

        public IEnumerable<ProductPhotoDto> ProductPhotos { get; set; }

        private class Handler : IRequestHandler<CreateCommand>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public Handler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                var result = await _context.Products.AddAsync(new Product
                {
                    ManufacturerId = request.Manufacturer.ManufacturerId,
                    Name = request.Name,
                    ProductNumber = request.ProductNumber
                }, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
                //return _mapper.Map<ProductLookupDto>(result.Entity);
            }
        }
    }
}