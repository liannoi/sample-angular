using FluentValidation;

namespace SampleAngular.Application.Storage.ProductPhotos.Commands.Delete
{
    public class DeleteProductPhotoCommandValidator : AbstractValidator<DeleteProductPhotoCommand>
    {
        public DeleteProductPhotoCommandValidator()
        {
            RuleFor(e => e.PhotoId).NotEmpty();
        }
    }
}