using E_Commerce.Domain.Enums;

namespace E_Commerce.Application.Features.RoleManagement.Commands.ManageRoleClaims
{
    public record ManageRoleClaimsCommand : IRequest<IEnumerable<PermissionsDto>>
    {
        public string RoleId { get; init; } = string.Empty;
        public List<string> ClaimsValues { get; init; } = [];
    }
}
