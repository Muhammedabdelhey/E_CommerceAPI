using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.RoleManagement.Queries.GetRoleClaims
{
    public class GetRoleClaimsQueryHandler : IRequestHandler<GetRoleClaimsQuery, IEnumerable<Claim>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public GetRoleClaimsQueryHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<Claim>> Handle(GetRoleClaimsQuery request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.roleId)
                ?? throw new NotFoundException($"Role with guid {request.roleId} not found");
            return await _roleManager.GetClaimsAsync(role);
        }
    }
}
