using FluentValidation;

namespace SampleAngular.Application.Storage.Manufacturers.Commands.Create
{
    public class CreateManufacturerCommandValidator : AbstractValidator<CreateManufacturerCommand>
    {
        public CreateManufacturerCommandValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty();
        }
    }
}