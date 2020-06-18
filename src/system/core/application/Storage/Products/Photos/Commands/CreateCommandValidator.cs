using FluentValidation;

namespace SampleAngular.Application.Storage.Products.Photos.Commands
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(e => e.ProductId).NotEmpty();
            RuleFor(e => e.Path).NotEmpty();
        }
    }
}