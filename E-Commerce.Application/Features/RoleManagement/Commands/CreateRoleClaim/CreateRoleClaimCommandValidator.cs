namespace E_Commerce.Application.Features.RoleManagement.Commands.CreateRoleClaim
{
    public class CreateRoleClaimCommandValidator : AbstractValidator<CreateRoleClaimCommand>
    {
        public CreateRoleClaimCommandValidator()
        {
            RuleFor(v => v.RoleId)
                .SetValidator(new GuidValidator());

            RuleFor(v => v.ClaimValue)
                .NotEmpty();
        }
    }
}
