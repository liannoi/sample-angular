using System.Threading.Tasks;
using MediatR;
using SampleAngular.Application.Common.Interfaces;
using SampleAngular.Application.Storage.Products;
using SampleAngular.Application.Storage.Products.Infrastructure.Photos.Queries.AsList;

namespace SampleAngular.Infrastructure.Fillers
{
    public class ProductFiller : IParentFiller<ProductLookupDto>
    {
        public async Task FillParent(IMediator mediator, ProductLookupDto product)
        {
            product.Photos = (await mediator.Send(new GetProductPhotosAsListQuery {ProductId = product.ProductId}))
                .ProductPhotos;
        }
    }
}