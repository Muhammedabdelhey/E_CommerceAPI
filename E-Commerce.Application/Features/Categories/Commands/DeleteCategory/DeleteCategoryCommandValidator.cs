﻿namespace E_Commerce.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator(EntityExistenceValidator<Category> categoryExistenceValidator)
        {
            RuleFor(v => v.Guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.Guid)
                        .SetValidator(categoryExistenceValidator);
                });
        }
    }
}
