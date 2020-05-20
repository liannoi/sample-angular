using FluentValidation;

namespace SampleAngular.Application.Storage.Products.Commands.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty();

            RuleFor(e => e.ProductNumber)
                .NotEmpty();
        }
    }
}