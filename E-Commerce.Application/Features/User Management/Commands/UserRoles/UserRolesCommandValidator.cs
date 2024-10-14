using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Features.User_Management.Commands.UserRoles
{
    public class UserRolesCommandValidator : AbstractValidator<UserRolesCommand>
    {
        public UserRolesCommandValidator(UserManager<User> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            RuleFor(v => v.UserId)
               .NotEmpty()
               .SetValidator(new GuidValidator());
               //.Must(userId => _userManager.FindByIdAsync(userId) != null);

            RuleFor(v => v.RolesNames)
                .NotEmpty();

            //RuleForEach(v => v.RolesNames)
            //    .Must(roleName => _roleManager.FindByNameAsync(roleName) != null);
        }
    }
}
