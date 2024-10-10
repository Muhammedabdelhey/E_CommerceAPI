using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Features.RoleManagement.Queries.GetRoles
{
    public record GetRolesQuery : IRequest<IEnumerable<IdentityRole>>;
}
