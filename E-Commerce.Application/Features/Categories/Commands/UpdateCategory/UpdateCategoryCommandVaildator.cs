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
                .NotEmpty();

            RuleFor(v => v.Name)
                .ValidateString(50);

            RuleFor(v => v.Image)
                .SetValidator(new ImageValidator());

            RuleFor(v => v.AttributeIds)
                .NotEmpty().WithMessage("AttributeIds cannot be empty; at least one attribute is required.");

            When(v => v.ParentId != null, () =>
            {
                RuleFor(v => v.ParentId.Value)
                   .SetValidator(new EntityExistenceValidator<Category>(_categoryRepository));
            });

            When(v => v.AttributeIds != null, () =>
            {
                RuleForEach(v => v.AttributeIds)
                    .SetValidator(new EntityExistenceValidator<Attribute>(_attributeRepository));
            });
        }
    }
}
