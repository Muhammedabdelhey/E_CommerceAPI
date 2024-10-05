namespace E_Commerce.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandVaildator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandVaildator(
            EntityExistenceValidator<Attribute> attributeExistenceValidator,
            EntityExistenceValidator<Category> categoryExistenceValidator)
        {
            RuleFor(v => v.guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.guid)
                        .SetValidator(categoryExistenceValidator);
                });

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
