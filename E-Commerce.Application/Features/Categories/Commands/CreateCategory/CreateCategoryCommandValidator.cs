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

            When(v => !string.IsNullOrWhiteSpace(v.ParentId), () =>
            {
                RuleFor(v => v.ParentId)
                    .SetValidator(new GuidValidator())
                    .DependentRules(() =>
                    {
                        RuleFor(v => v.ParentId)
                            .SetValidator(new EntityExistenceValidator<Category>(_categoryRepository));
                    });
            });

            When(v => v.AttributeIds != null, () =>
            {
                RuleForEach(v => v.AttributeIds)
                    .SetValidator(new GuidValidator())
                    .DependentRules(() =>
                    {
                        RuleForEach(v => v.AttributeIds)
                            .SetValidator(new EntityExistenceValidator<Attribute>(_attributeRepository));
                    });
            });

        }
    }
}
