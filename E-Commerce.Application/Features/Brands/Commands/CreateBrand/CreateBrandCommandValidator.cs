namespace E_Commerce.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(v => v.Name)
                .ValidateString(50);


            RuleFor(v => v.Image)
                .SetValidator(new ImageValidator());

        }
    }
}
