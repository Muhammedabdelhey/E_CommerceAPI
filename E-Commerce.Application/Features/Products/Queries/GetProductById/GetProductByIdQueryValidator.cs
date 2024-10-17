namespace E_Commerce.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator(EntityExistenceValidator<Product> productExistenceValidator)
        {
            RuleFor(v => v.Guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.Guid)
                        .SetValidator(productExistenceValidator);
                });
        }
    }
}
