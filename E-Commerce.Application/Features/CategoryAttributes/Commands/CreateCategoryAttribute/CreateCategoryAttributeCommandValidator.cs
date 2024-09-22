namespace E_Commerce.Application.Features.CategoryAttributes.Commands.CreateCategoryAttribute
{
    public class CreateCategoryAttributeCommandValidator : AbstractValidator<CreateCategoryAttributeCommand>
    {
        public CreateCategoryAttributeCommandValidator()
        {
            RuleFor(x => x.CategoryId)
             .NotEmpty();
        }
    }
}
