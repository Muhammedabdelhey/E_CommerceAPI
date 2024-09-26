namespace E_Commerce.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly IBaseRepository<Attribute> _attributeRepository;
        private readonly IBaseRepository<Category> _categoryRepository;

        public CreateCategoryCommandValidator(IBaseRepository<Attribute> attributeRepository,
            IBaseRepository<Category> categoryRepository)
        {
            _attributeRepository = attributeRepository;
            _categoryRepository = categoryRepository;

            RuleFor(v => v.Name)
                .ValidateString(50);

            RuleFor(v => v.Image)
                .SetValidator(new ImageValidator());

            When(v => v.ParentId.HasValue, () =>
            {
                RuleFor(v => v.ParentId.Value)
                    .SetValidator(new EntityExistenceValidator<Category>(_categoryRepository));
            });

            RuleFor(v => v.AttributeIds)
                .NotEmpty().WithMessage("AttributeIds cannot be empty; at least one attribute is required.");

            When(v => v.AttributeIds != null, () =>
            {
                RuleForEach(v => v.AttributeIds)
                    .SetValidator(new EntityExistenceValidator<Attribute>(_attributeRepository));
            });
        }
    }
}
