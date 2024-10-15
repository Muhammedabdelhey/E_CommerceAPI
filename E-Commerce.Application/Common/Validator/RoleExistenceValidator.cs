using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Common.Validator
{
    public class RoleExistenceValidator : AbstractValidator<string>
    {
        RoleManager<IdentityRole> _roleManager;
        public RoleExistenceValidator(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;

            RuleFor(roleName => roleName)
                .NotEmpty()
                .MustAsync(RoleExists)
                .WithMessage(roleName => $"Role With Name: {roleName} Not Exist");
        }

        private async Task<bool> RoleExists(string roleName, CancellationToken cancellationToken)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            return roleExists;
        }
    }
}
