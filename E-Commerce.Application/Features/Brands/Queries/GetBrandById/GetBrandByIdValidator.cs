namespace E_Commerce.Application.Features.Brands.Queries.GetBrandById
{
    public class GetBrandByIdValidator : AbstractValidator<GetBrandByIdQuery>
    {
        public GetBrandByIdValidator(EntityExistenceValidator<Brand> brandExistenceValidator)
        {
            RuleFor(v => v.guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .SetValidator(brandExistenceValidator);
        }
    }
}
