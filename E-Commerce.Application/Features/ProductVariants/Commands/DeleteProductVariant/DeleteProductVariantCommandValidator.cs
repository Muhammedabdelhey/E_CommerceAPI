namespace E_Commerce.Application.Features.ProductVariants.Commands.DeleteProductVariant
{
    public class DeleteProductVariantCommandValidator : AbstractValidator<DeleteProductVariantCommand>
    {
        public DeleteProductVariantCommandValidator(
            EntityExistenceValidator<ProductVariant> productVariantExistenceValidator,
            EntityExistenceValidator<Product> productExistenceValidator)
        {
            RuleFor(v => v.productVariantId)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.productVariantId)
                        .SetValidator(productVariantExistenceValidator);
                });

            RuleFor(v => v.productId)
                  .NotEmpty()
                  .SetValidator(new GuidValidator())
                  .DependentRules(() =>
                  {
                      RuleFor(v => v.productId)
                          .SetValidator(productExistenceValidator);
                  });
        }
    }
}
