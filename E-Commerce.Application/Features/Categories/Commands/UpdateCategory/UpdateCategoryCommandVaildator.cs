namespace E_Commerce.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandVaildator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandVaildator()
        {
            RuleFor(v => v.guid)
                .SetValidator(new GuidValidator());

            RuleFor(v => v.Name)
                .ValidateString(50);

            RuleFor(v => v.ParentId)
                .Must(IsValidGuid)
                .WithMessage("Invalid GUID Format");
            RuleFor(v => v.Image)
                .SetValidator(new ImageValidator());
        }
        private bool IsValidGuid(string guid)
        {
            if (guid == null)
            {
                return true;
            }
            return Guid.TryParse(guid, out _);
        }
    }
}
