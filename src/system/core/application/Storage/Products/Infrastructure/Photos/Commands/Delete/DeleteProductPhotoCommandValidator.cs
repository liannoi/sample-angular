using FluentValidation;

namespace SampleAngular.Application.Storage.Products.Infrastructure.Photos.Commands.Delete
{
    public class DeleteProductPhotoCommandValidator : AbstractValidator<DeleteProductPhotoCommand>
    {
        public DeleteProductPhotoCommandValidator()
        {
            RuleFor(e => e.PhotoId).NotEmpty();
        }
    }
}