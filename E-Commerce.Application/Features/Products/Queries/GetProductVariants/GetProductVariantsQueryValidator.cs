namespace E_Commerce.Application.Features.Products.Queries.GetProductVariants
{
    public class GetProductVariantsQueryValidator : AbstractValidator<GetProductVariantsQuery>
    {
        public GetProductVariantsQueryValidator(EntityExistenceValidator<Product> productExistenceValidator)
        {
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
