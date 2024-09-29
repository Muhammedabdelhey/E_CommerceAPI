﻿namespace E_Commerce.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandVaildator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandVaildator(EntityExistenceValidator<Category> categoryExistenceValidator,
            EntityExistenceValidator<Attribute> attributeExistenceValidator)
        {
            RuleFor(v => v.guid)
                .SetValidator(new GuidValidator());

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
