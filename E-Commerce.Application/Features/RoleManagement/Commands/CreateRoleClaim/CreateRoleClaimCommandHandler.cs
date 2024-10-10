using E_Commerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace E_Commerce.Application.Features.RoleManagement.Commands.CreateRoleClaim
{
    public class CreateRoleClaimCommandHandler : IRequestHandler<CreateRoleClaimCommand, Claim>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public CreateRoleClaimCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<Claim> Handle(CreateRoleClaimCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.RoleId)
                ?? throw new NotFoundException($"Role With Guid {request.RoleId} not Exist");
            Claim claim = new(typeof(Permissions).Name.ToLower(), request.ClaimValue);
            await _roleManager.AddClaimAsync(role, claim);
            return claim;
        }
    }
}
