using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Application.Common;

namespace SampleAngular.Application.Storage.Products.Core.Commands
{
    public class DeleteCommand : IRequest
    {
        public int ProductId { get; set; }

        private class Handler : IRequestHandler<DeleteCommand>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public Handler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(DeleteCommand request,
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

                return Unit.Value;
                //return _mapper.Map<ProductLookupDto>(fined);
            }

            private async Task ClearProductPhotosAsync(DeleteCommand request,
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