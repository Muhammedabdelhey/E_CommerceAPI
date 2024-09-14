namespace E_Commerce.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommnadValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommnadValidator()
        {
            RuleFor(v => v.Name)
                .ValidateString(50);
            RuleFor(v => v.ParentId)
                .Must(IsValidGuid)
                .WithMessage("Invalid GUID Format");
        }
        private bool IsValidGuid(string id)
        {
            if(id == null)
            {
                return true;
            }
            return Guid.TryParse(id, out _);
        }
    }
}
