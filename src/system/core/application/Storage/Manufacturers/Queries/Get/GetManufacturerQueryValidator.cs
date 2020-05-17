using FluentValidation;

namespace SampleAngular.Application.Storage.Manufacturers.Queries.Get
{
    public class GetManufacturerQueryValidator : AbstractValidator<GetManufacturerQuery>
    {
        public GetManufacturerQueryValidator()
        {
            RuleFor(e => e.ManufacturerId)
                .NotEmpty();
        }
    }
}