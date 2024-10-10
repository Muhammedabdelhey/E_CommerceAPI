using System.Security.Claims;

namespace E_Commerce.Application.Features.RoleManagement.Commands.CreateRoleClaim
{
    public record CreateRoleClaimCommand : IRequest<Claim>
    {
        public string RoleId { get; init; } = string.Empty;
        public string ClaimValue { get; init; } = string.Empty;
    }
}
