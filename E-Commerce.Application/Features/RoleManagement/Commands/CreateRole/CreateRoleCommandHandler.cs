using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Features.RoleManagement.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, IdentityRole>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public CreateRoleCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IdentityRole> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            IdentityRole role = new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.name,
                NormalizedName = request.name.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            };
            if (await _roleManager.FindByNameAsync(role.Name) is not null)
                throw new ValidationException($"Role {role.Name} already Exist");
            await _roleManager.CreateAsync(role);
            return role;
        }
    }
}
