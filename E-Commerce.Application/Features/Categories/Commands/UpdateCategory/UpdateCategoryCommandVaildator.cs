namespace E_Commerce.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandVaildator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly IBaseRepository<Attribute> _attributeRepository;

        public UpdateCategoryCommandVaildator(IBaseRepository<Attribute> attributeRepository)
        {
            _attributeRepository = attributeRepository;
            RuleFor(v => v.guid)
                .NotEmpty();

            RuleFor(v => v.Name)
                .ValidateString(50);

            RuleFor(v => v.Image)
                .SetValidator(new ImageValidator());

            RuleFor(v => v.AttributeIds)
                .NotEmpty().WithMessage("AttributeIds cannot be empty; at least one attribute is required.");

            RuleForEach(v => v.AttributeIds)
                .SetValidator(new EntityExistenceValidator<Attribute>(_attributeRepository));
        }
    }
}
