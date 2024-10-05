namespace E_Commerce.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandVaildator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandVaildator(
            EntityExistenceValidator<Product> productExistenceValidator,
            EntityExistenceValidator<Category> categoryExistenceValidator,
            EntityExistenceValidator<Brand> brandExistenceValidator)
        {
            RuleFor(v => v.guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.guid)
                        .SetValidator(productExistenceValidator);
                });
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
