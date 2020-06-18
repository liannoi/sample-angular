using FluentValidation;

namespace SampleAngular.Application.Storage.Manufacturers.Commands.Create
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