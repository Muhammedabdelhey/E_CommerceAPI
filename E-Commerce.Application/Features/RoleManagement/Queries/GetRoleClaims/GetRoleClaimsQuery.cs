using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace E_Commerce.Application.Features.RoleManagement.Queries.GetRoleClaims
{
    public record GetRoleClaimsQuery(string roleId) : IRequest<IEnumerable<PermissionsDto>>;

}
