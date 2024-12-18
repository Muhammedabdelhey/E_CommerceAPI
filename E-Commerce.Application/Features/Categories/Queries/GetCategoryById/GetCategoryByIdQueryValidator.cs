﻿namespace E_Commerce.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
    {
        public GetCategoryByIdQueryValidator(EntityExistenceValidator<Category> categoryExistenceValidator)
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
