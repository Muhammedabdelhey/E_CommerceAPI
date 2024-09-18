namespace E_Commerce.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdValidator : AbstractValidator<GetCategoryByIdCommand>
    {
        public GetCategoryByIdValidator()
        {
            RuleFor(v => v.guid)
                .SetValidator(new GuidValidator());
        }
    }
}
