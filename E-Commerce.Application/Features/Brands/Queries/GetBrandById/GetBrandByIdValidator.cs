namespace E_Commerce.Application.Features.Brands.Queries.GetBrandById
{
    public class GetBrandByIdValidator : AbstractValidator<GetBrandByIdQuery>
    {
        public GetBrandByIdValidator(EntityExistenceValidator<Brand> brandExistenceValidator)
        {
            RuleFor(v => v.Guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.Guid)
                        .SetValidator(brandExistenceValidator);
                });
        }
    }
}
