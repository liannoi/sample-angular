using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common.Interfaces;

namespace SampleAngular.Application.Storage.Products.Infrastructure.Photos.Commands.Delete
{
    public class DeleteProductPhotoCommand : IRequest<ProductPhotoLookupDto>
    {
        public int PhotoId { get; set; }

        public class
            DeleteProductPhotoCommandHandler : IRequestHandler<DeleteProductPhotoCommand, ProductPhotoLookupDto>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public DeleteProductPhotoCommandHandler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductPhotoLookupDto> Handle(DeleteProductPhotoCommand request,
                CancellationToken cancellationToken)
            {
                var fined = await _context.ProductPhotos
                    .Where(e => e.PhotoId == request.PhotoId)
                    .FirstOrDefaultAsync(cancellationToken);

                _context.ProductPhotos.Remove(fined);
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ProductPhotoLookupDto>(fined);
            }
        }
    }
}