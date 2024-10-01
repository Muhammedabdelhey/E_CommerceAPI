namespace E_Commerce.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator(EntityExistenceValidator<Product> productExistenceValidator)
        {
            RuleFor(v => v.guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .SetValidator(productExistenceValidator);
        }
    }
}
