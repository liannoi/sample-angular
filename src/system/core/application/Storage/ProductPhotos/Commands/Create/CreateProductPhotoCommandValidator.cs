using FluentValidation;

namespace SampleAngular.Application.Storage.ProductPhotos.Commands.Create
{
    public class CreateProductPhotoCommandValidator : AbstractValidator<CreateProductPhotoCommand>
    {
        public CreateProductPhotoCommandValidator()
        {
            RuleFor(e => e.ProductId).NotEmpty();
            RuleFor(e => e.Path).NotEmpty();
        }
    }
}