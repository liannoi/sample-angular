using FluentValidation;

namespace SampleAngular.Application.Storage.Manufacturers.Commands
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty();
        }
    }
}