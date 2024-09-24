namespace E_Commerce.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandVaildator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandVaildator()
        {
            RuleFor(v => v.guid)
                .NotEmpty();

            RuleFor(v => v.Name)
                .ValidateString(50);

            RuleFor(v => v.Image)
                .SetValidator(new ImageValidator());
        }
    }
}
