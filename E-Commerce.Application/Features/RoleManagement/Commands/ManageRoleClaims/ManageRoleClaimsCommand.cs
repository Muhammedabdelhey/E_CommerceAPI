using E_Commerce.Domain.Enums;
using System.Security.Claims;

namespace E_Commerce.Application.Features.RoleManagement.Commands.ManageRoleClaims
{
    public record ManageRoleClaimsCommand : IRequest<IEnumerable<PermissionsDto>>
    {
        public string RoleId { get; init; } = string.Empty;
        public List<Permissions> ClaimsValues{ get; init; } = [];
    }
}
