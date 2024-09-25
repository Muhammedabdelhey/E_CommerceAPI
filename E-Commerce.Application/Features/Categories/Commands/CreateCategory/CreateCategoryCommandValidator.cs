using FluentValidation;

namespace E_Commerce.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly IBaseRepository<Attribute> _attributeRepository;
        private readonly IBaseRepository<Category> _caetgoryRepository;
        public CreateCategoryCommandValidator(IBaseRepository<Attribute> attributeRepository,
            IBaseRepository<Category> categoryRepository)
        {
            _attributeRepository = attributeRepository;
            _caetgoryRepository = categoryRepository;

            RuleFor(v => v.Name)
                .ValidateString(50);

            RuleFor(v => v.Image)
                .SetValidator(new ImageValidator());

            RuleFor(v => v.ParentId)
                .SetValidator(new EntityExistenceValidator<Category>(_caetgoryRepository));

            RuleFor(v => v.AttributeIds)
                .NotEmpty().WithMessage("AttributeIds cannot be empty; at least one attribute is required.");

            RuleForEach(v => v.AttributeIds)
                .SetValidator(new EntityExistenceValidator<Attribute>(_attributeRepository));
        }
    }
}
