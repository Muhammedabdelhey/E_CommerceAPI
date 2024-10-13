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
                ?? throw new NotFoundException($"Role With Guid {request.RoleId} not Exist");

            var existingClaims = await _roleManager.GetClaimsAsync(role);

            foreach (var claim in existingClaims)
            {
                if (!request.ClaimsValues.Contains(Enum.Parse<Permissions>(claim.Value)))
                {
                    await _roleManager.RemoveClaimAsync(role, claim);
                }
            }

            foreach (var permission in request.ClaimsValues)
            {
                if (!existingClaims.Any(c => c.Value == permission.ToString()))
                {
                    var newClaim = new Claim(typeof(Permissions).Name, permission.ToString());
                    await _roleManager.AddClaimAsync(role, newClaim);
                }
            }
            var currentClaims = await _roleManager.GetClaimsAsync(role);
            return _mapper.Map<IEnumerable<PermissionsDto>>(currentClaims);
        }
    }
}
