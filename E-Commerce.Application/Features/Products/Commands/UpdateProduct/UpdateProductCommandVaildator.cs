namespace E_Commerce.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandVaildator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandVaildator(EntityExistenceValidator<Category> categoryExistenceValidator,
            EntityExistenceValidator<Brand> brandExistenceValidator)
        {
            RuleFor(v => v.guid)
                .SetValidator(new GuidValidator());

            RuleFor(v => v.Name)
                .ValidateString(100);

            RuleFor(v => v.Description)
                .NotEmpty();

            RuleFor(v => v.CategoryId)
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.CategoryId)
                        .SetValidator(categoryExistenceValidator);
                });

            RuleFor(v => v.BrandId)
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.BrandId)
                        .SetValidator(brandExistenceValidator);
                });
        }
    }
}
