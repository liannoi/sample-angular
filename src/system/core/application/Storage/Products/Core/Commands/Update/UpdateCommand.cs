using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common.Interfaces;
using SampleAngular.Application.Storage.Manufacturers.Models;
using SampleAngular.Application.Storage.Products.Photos.Models;

namespace SampleAngular.Application.Storage.Products.Core.Commands.Update
{
    public class UpdateCommand : IRequest
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public ManufacturerDto Manufacturer { get; set; }

        public IEnumerable<ProductPhotoDto> ProductPhotos { get; set; }

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
                var fined = await _context.Products
                    .Where(e => e.ProductId == request.ProductId)
                    .FirstOrDefaultAsync(cancellationToken);

                fined.Manufacturer = await _context.Manufacturers
                    .Where(e => e.ManufacturerId == request.Manufacturer.ManufacturerId)
                    .FirstOrDefaultAsync(cancellationToken);

                fined.Name = request.Name;
                fined.ProductNumber = request.ProductNumber;
                _context.Products.Update(fined);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
                //return _mapper.Map<ProductLookupDto>(fined);
            }
        }
    }
}