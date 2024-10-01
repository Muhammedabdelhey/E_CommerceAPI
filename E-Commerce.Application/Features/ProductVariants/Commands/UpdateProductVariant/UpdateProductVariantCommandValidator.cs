namespace E_Commerce.Application.Features.ProductVariants.Commands.UpdateProductVariant
{
    public class UpdateProductVariantCommandValidator : AbstractValidator<UpdateProductVariantCommand>
    {
        public UpdateProductVariantCommandValidator(
            EntityExistenceValidator<ProductVariant> productVariantExistenceValidator,
            EntityExistenceValidator<Product> productExistenceValidator,
            EntityExistenceValidator<Attribute> attributeExistenceValidator)
        {
            RuleFor(v => v.guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.guid)
                        .SetValidator(productVariantExistenceValidator);
                });

            RuleFor(v => v.ProductId)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.ProductId)
                        .SetValidator(productExistenceValidator);
                });

            RuleFor(v => v.Stock)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);

            RuleFor(v => v.Price)
                .NotEmpty()
                .GreaterThan(0);

            When(v => v.Image != null, () =>
            {
                RuleFor(v => v.Image)
                    .SetValidator(new ImageValidator());
            });

            RuleFor(v => v.Attributes)
                .NotEmpty();

            RuleForEach(v => v.Attributes)
                .NotEmpty()
                .ChildRules(attribute =>
                {
                    // Validate the GUID field within each attribute
                    attribute.RuleFor(a => a.Guid)
                       .NotEmpty()
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
