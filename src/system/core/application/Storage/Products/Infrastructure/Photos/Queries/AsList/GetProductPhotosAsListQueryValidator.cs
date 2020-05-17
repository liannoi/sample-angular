using FluentValidation;

namespace SampleAngular.Application.Storage.Products.Infrastructure.Photos.Queries.AsList
{
    public class GetProductPhotosAsListQueryValidator : AbstractValidator<GetProductPhotosAsListQuery>
    {
        public GetProductPhotosAsListQueryValidator()
        {
            RuleFor(e => e.ProductId).NotEmpty();
        }
    }
}