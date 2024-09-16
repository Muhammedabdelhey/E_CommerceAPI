namespace E_Commerce.Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {

            RuleFor(v => v.Id)
                .SetValidator(new GuidValidator());

            RuleFor(v => v.Name)
                .ValidateString(50);
        }
    }
}
