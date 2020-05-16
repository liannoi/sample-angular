using FluentValidation;

namespace SampleAngular.Application.Storage.Products.Queries.Get
{
    public class GetProductQueryValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductQueryValidator()
        {
            RuleFor(e => e.ProductId).NotEmpty();
        }
    }
}