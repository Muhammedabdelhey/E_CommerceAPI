namespace E_Commerce.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandVaildator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly IBaseRepository<Attribute> _attributeRepository;
        private readonly IBaseRepository<Category> _categoryRepository;

        public UpdateCategoryCommandVaildator(IBaseRepository<Attribute> attributeRepository,
            IBaseRepository<Category> categoryRepository)
        {
            _attributeRepository = attributeRepository;
            _categoryRepository = categoryRepository;

            RuleFor(v => v.guid)
                .SetValidator(new GuidValidator());

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
