namespace E_Commerce.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator(EntityExistenceValidator<Category> categoryExistenceValidator,
            EntityExistenceValidator<Brand> brandExistenceValidator)
        {
            RuleFor(v => v.Name)
                .ValidateString(100);

            RuleFor(v => v.Description)
                .NotEmpty();

            RuleFor(v => v.CategoryId)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.CategoryId)
                        .SetValidator(categoryExistenceValidator);
                });

            RuleFor(v => v.BrandId)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.BrandId)
                        .SetValidator(brandExistenceValidator);
                });
        }
    }
}
