namespace E_Commerce.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(v => v.guid)
                .SetValidator(new GuidValidator());
        }
    }
}
