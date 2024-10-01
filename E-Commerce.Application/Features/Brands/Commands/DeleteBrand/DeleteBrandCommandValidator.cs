namespace E_Commerce.Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandValidator : AbstractValidator<DeleteBrandCommand>
    {
        public DeleteBrandCommandValidator(EntityExistenceValidator<Brand> brandExistenceValidator)
        {
            RuleFor(v => v.guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .SetValidator(brandExistenceValidator);
        }
    }
}
