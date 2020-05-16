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
                    .Where(e => e.ProductId == request.ProductId)
                    .FirstOrDefaultAsync(cancellationToken);

                _context.Products.Remove(fined);
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ProductLookupDto>(fined);
            }
        }
    }
}