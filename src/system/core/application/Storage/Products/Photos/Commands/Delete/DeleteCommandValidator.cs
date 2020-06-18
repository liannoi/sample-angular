using FluentValidation;

namespace SampleAngular.Application.Storage.Products.Photos.Commands.Delete
{
    public class DeleteCommandValidator : AbstractValidator<DeleteCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(e => e.PhotoId)
                .NotEmpty();
        }
    }
}