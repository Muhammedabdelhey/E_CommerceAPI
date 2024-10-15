using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Features.User_Management.Commands.UserRoles
{
    public class UserRolesCommandHandler : IRequestHandler<UserRolesCommand, IEnumerable<string>>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesCommandHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<string>> Handle(UserRolesCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId)
                ?? throw new ValidationException($"User With Id {request.UserId} Not Exist");

            var existingRoles = await _userManager.GetRolesAsync(user);

            var rolesToRemove = existingRoles.Except(request.RolesNames);
            foreach (var role in rolesToRemove)
            {
                await _userManager.RemoveFromRoleAsync(user, role);
            }

            var rolesToAdd = request.RolesNames.Except(existingRoles);
            foreach (var roleName in rolesToAdd)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }
            return await _userManager.GetRolesAsync(user);
        }
    }
}
