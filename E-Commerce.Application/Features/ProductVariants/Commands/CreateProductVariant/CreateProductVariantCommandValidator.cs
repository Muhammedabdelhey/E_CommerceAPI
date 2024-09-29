using E_Commerce.Application.Common.Validator;

namespace E_Commerce.Application.Features.ProductVariants.Commands.CreateProductVariant
{
    public class CreateProductVariantCommandValidator : AbstractValidator<CreateProductVariantCommand>
    {
        public CreateProductVariantCommandValidator(EntityExistenceValidator<Product> productExistenceValidator,
            EntityExistenceValidator<Attribute> attributeExistenceValidator)
        {
            RuleFor(v => v.Stock)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("Stock must be greater than or equal to 0.");

            RuleFor(v => v.Price)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0.");

            When(v => v.Image != null, () =>
            {
                RuleFor(v => v.Image)
                    .SetValidator(new ImageValidator());
            });

            When(v => v.ProductId != null, () =>
            {
                RuleFor(v => v.ProductId)
                    .SetValidator(new GuidValidator())
                    .DependentRules(() =>
                    {
                        RuleFor(v => v.ProductId)
                            .SetValidator(productExistenceValidator);
                    });
            });

            RuleForEach(v => v.Attributes)
                .NotEmpty()
                .ChildRules(attribute =>
                {
                    // Validate the GUID field within each attribute
                    attribute.RuleFor(a => a.Guid)
                       .NotEmpty().WithMessage("Attribute GUID cannot be empty.")
                       .SetValidator(new GuidValidator())
                       .DependentRules(() =>
                       {
                           attribute.RuleFor(a => a.Guid)
                               .SetValidator(attributeExistenceValidator);
                       });
                    //  validate the Value of the attribute
                    attribute.RuleFor(a => a.Value)
                    .NotEmpty().WithMessage("Attribute value cannot be empty.");
                });
        }
    }
}
