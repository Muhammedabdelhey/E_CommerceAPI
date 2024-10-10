namespace E_Commerce.Application.Features.RoleManagement.Commands.CreateRole
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(v => v.name)
                .ValidateString(256);
        }
    }
}
