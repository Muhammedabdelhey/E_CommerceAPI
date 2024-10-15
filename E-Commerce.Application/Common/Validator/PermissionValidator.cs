using E_Commerce.Domain.Enums;

namespace E_Commerce.Application.Common.Validator
{
    public class PermissionValidator : AbstractValidator<string>
    {
        public PermissionValidator()
        {
            RuleFor(permission => permission)
                .Must(IsValidPermission)
                .WithMessage(permission => $"Invalid Permission Provided. Permission: '{permission}' Not Exist.");
        }

        private bool IsValidPermission(string permission)
        {
            return Enum.IsDefined(typeof(Permissions), permission);
        }
    }
}
