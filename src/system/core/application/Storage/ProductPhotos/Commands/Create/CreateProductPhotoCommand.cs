using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SampleAngular.Application.Common.Interfaces;
using SampleAngular.Domain.Entities;

namespace SampleAngular.Application.Storage.ProductPhotos.Commands.Create
{
    public class CreateProductPhotoCommand : IRequest<ProductPhotoLookupDto>
    {
        public int PhotoId { get; set; }
        public int ProductId { get; set; }
        public string Path { get; set; }

        public class
            CreateProductPhotoCommandHandler : IRequestHandler<CreateProductPhotoCommand, ProductPhotoLookupDto>
        {
            private readonly ISampleAngularContext _context;
            private readonly IMapper _mapper;

            public CreateProductPhotoCommandHandler(ISampleAngularContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductPhotoLookupDto> Handle(CreateProductPhotoCommand request,
                CancellationToken cancellationToken)
            {
                var result = await _context.ProductPhotos.AddAsync(
                    new ProductPhoto {ProductId = request.ProductId, Path = request.Path}, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ProductPhotoLookupDto>(result.Entity);
            }
        }
    }
}