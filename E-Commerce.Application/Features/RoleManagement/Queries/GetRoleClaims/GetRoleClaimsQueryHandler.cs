using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace E_Commerce.Application.Features.RoleManagement.Queries.GetRoleClaims
{
    public class GetRoleClaimsQueryHandler : IRequestHandler<GetRoleClaimsQuery, IEnumerable<PermissionsDto>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public GetRoleClaimsQueryHandler(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionsDto>> Handle(GetRoleClaimsQuery request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.roleId)
                ?? throw new NotFoundException($"Role with guid {request.roleId} not found");
            var claims = await _roleManager.GetClaimsAsync(role);

            return _mapper.Map<IEnumerable<PermissionsDto>>(claims);
        }
    }
}
