using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SampleAngular.Application.Common;
using SampleAngular.Domain.Entities;

namespace SampleAngular.Application.Storage.Products.Photos.Commands
{
    public class CreateCommand : IRequest
    {
        public int PhotoId { get; set; }
        public int ProductId { get; set; }
        public string Path { get; set; }

        private class Handler : IRequestHandler<CreateCommand>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public Handler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CreateCommand request,
                CancellationToken cancellationToken)
            {
                var result = await _context.ProductPhotos.AddAsync(
                    new ProductPhoto {ProductId = request.ProductId, Path = request.Path}, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
                // return _mapper.Map<ProductPhotoLookupDto>(result.Entity);
            }
        }
    }
}