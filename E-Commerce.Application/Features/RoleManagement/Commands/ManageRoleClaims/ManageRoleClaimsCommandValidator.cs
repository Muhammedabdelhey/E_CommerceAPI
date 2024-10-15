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
                .SetValidator(new PermissionValidator());
        }
    }
}
