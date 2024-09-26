namespace E_Commerce.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandVaildator : AbstractValidator<UpdateProductCommand>
    {
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IBaseRepository<Brand> _brandRepository;
        public UpdateProductCommandVaildator(IBaseRepository<Category> categoryRepository, IBaseRepository<Brand> brandRepository)
        {
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;

            RuleFor(v => v.Name)
                .ValidateString(100);

            RuleFor(v => v.CategoryId)
                .NotEmpty()
                .SetValidator(new EntityExistenceValidator<Category>(_categoryRepository));

            RuleFor(v => v.BrandId)
                .NotEmpty()
                .SetValidator(new EntityExistenceValidator<Brand>(_brandRepository));
        }
    }
}
