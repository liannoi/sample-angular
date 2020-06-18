using FluentValidation;

namespace SampleAngular.Application.Storage.Products.Core.Commands
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty();

            RuleFor(e => e.ProductNumber)
                .NotEmpty();
        }
    }
}