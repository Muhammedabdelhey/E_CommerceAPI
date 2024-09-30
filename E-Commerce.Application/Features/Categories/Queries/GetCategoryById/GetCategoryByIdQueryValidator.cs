namespace E_Commerce.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
    {
        public GetCategoryByIdQueryValidator(EntityExistenceValidator<Category> categoryExistenceValidator)
        {
            RuleFor(v => v.guid)
                .SetValidator(new GuidValidator())
                .SetValidator(categoryExistenceValidator);
        }
    }
}
