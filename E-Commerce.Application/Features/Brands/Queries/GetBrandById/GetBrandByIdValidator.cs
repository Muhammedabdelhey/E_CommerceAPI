namespace E_Commerce.Application.Features.Brands.Queries.GetBrandById
{
    public class GetBrandByIdValidator : AbstractValidator<GetBrandByIdQuery>
    {
        public GetBrandByIdValidator()
        {
            RuleFor(v => v.guid)
                .SetValidator(new GuidValidator());
        }
    }
}
