using E_Commerce.Domain.Enums;
using System.Security;

namespace E_Commerce.Application.Features.RoleManagement.Commands.ManageRoleClaims
{
    public class ManageRoleClaimsCommandValidator : AbstractValidator<ManageRoleClaimsCommand>
    {
        public ManageRoleClaimsCommandValidator()
        {
            RuleFor(v => v.RoleId)
                .SetValidator(new GuidValidator());

            RuleFor(v => v.ClaimsValues)
                .NotEmpty();

            RuleForEach(v => v.ClaimsValues)
                .Must(claim => Enum.IsDefined(typeof(Permissions), claim))
                .WithMessage("Invalid permission provided. Permission '{PropertyValue}' is not valid.");
        }
    }
}
