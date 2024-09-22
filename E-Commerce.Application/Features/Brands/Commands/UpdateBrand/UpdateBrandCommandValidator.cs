namespace E_Commerce.Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {
            RuleFor(v => v.guid)
                .NotEmpty();

            RuleFor(v => v.Name)
                .ValidateString(50);

            RuleFor(v => v.Image)
                .SetValidator(new ImageValidator());

        }
    }
}
