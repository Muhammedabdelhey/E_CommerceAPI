namespace E_Commerce.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator(EntityExistenceValidator<Attribute> attributeExistenceValidator,
                    EntityExistenceValidator<Category> categoryExistenceValidator)
        {
            RuleFor(v => v.Name)
                .ValidateString(50);

            When(v => v.Image != null, () =>
            {
                RuleFor(v => v.Image)
                    .SetValidator(new ImageValidator());
            });

            When(v => !string.IsNullOrWhiteSpace(v.ParentId), () =>
            {
                RuleFor(v => v.ParentId)
                    .SetValidator(new GuidValidator())
                    .DependentRules(() =>
                    {
                        RuleFor(v => v.ParentId)
                            .SetValidator(categoryExistenceValidator);
                    });
            });

            When(v => v.AttributeIds != null, () =>
            {
                RuleForEach(v => v.AttributeIds)
                    .NotEmpty()
                    .SetValidator(new GuidValidator())
                    .DependentRules(() =>
                    {
                        RuleForEach(v => v.AttributeIds)
                            .SetValidator(attributeExistenceValidator);
                    });
            });
        }
    }
}
