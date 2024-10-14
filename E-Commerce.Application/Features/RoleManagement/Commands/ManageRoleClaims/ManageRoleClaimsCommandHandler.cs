using E_Commerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace E_Commerce.Application.Features.RoleManagement.Commands.ManageRoleClaims
{
    public class ManageRoleClaimsCommandHandler : IRequestHandler<ManageRoleClaimsCommand, IEnumerable<PermissionsDto>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public ManageRoleClaimsCommandHandler(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionsDto>> Handle(ManageRoleClaimsCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.RoleId)
                ?? throw new NotFoundException($"Role with ID {request.RoleId} does not exist");

            var existingClaims = await _roleManager.GetClaimsAsync(role);
            var existingClaimValues = existingClaims.Select(c => c.Value).ToList();

            var claimsToRemove = existingClaimValues.Except(request.ClaimsValues);
            foreach (var claimValue in claimsToRemove)
            {
                var claim = existingClaims.FirstOrDefault(c => c.Value == claimValue);
                if (claim != null)
                {
                    await _roleManager.RemoveClaimAsync(role, claim);
                }
            }

            var claimsToAdd = request.ClaimsValues.Except(existingClaimValues);
            foreach (var claimValue in claimsToAdd)
            {
                var newClaim = new Claim(typeof(Permissions).Name, claimValue);
                await _roleManager.AddClaimAsync(role, newClaim);
            }

            var updatedClaims = await _roleManager.GetClaimsAsync(role);
            return _mapper.Map<IEnumerable<PermissionsDto>>(updatedClaims);
        }
    }
}
