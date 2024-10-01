namespace E_Commerce.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator(EntityExistenceValidator<Product> productExistenceValidator)
        {
            RuleFor(v => v.guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .SetValidator(productExistenceValidator);
        }
    }
}
