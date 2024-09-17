using Microsoft.AspNetCore.Http;

namespace E_Commerce.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
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
            if (guid != null)
            {
                return Guid.TryParse(guid, out _);
            }
            return true;
        }
    }
}
