using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Features.RoleManagement.Queries.GetRoles
{

    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, IEnumerable<IdentityRole>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public GetRolesQueryHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<IdentityRole>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            return await _roleManager.Roles.ToListAsync();
        }
    }
}
