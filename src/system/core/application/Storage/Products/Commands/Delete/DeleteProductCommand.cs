using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common.Interfaces;

namespace SampleAngular.Application.Storage.Products.Commands.Delete
{
    public class DeleteProductCommand : IRequest<ProductLookupDto>
    {
        public int ProductId { get; set; }

        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductLookupDto>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public DeleteProductCommandHandler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductLookupDto> Handle(DeleteProductCommand request,
                CancellationToken cancellationToken)
            {
                var fined = await _context.Products
                    .Where(product => product.ProductId == request.ProductId)
                    .FirstOrDefaultAsync(cancellationToken);

                #region Work with dependencies

                await ClearProductPhotosAsync(request, cancellationToken);

                #endregion

                _context.Products.Remove(fined);
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ProductLookupDto>(fined);
            }

            private async Task ClearProductPhotosAsync(DeleteProductCommand request,
                CancellationToken cancellationToken)
            {
                await _context.ProductPhotos
                    .Where(photo => photo.ProductId == request.ProductId)
                    .ForEachAsync(photo => _context.ProductPhotos.Remove(photo), cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}