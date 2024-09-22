namespace E_Commerce.Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandValidator : AbstractValidator<DeleteBrandCommand>
    {
        public DeleteBrandCommandValidator()
        {
            RuleFor(v => v.guid)
                .NotEmpty();
        }
    }
}
