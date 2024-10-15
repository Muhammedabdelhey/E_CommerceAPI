using E_Commerce.Application.Features.RoleManagement;

namespace E_Commerce.Application.Features.User_Management.Commands.UserClaims
{
    public record UserClaimsCommand : IRequest<IEnumerable<PermissionsDto>>
    {
        public string UserId { get; init; } = string.Empty;
        public List<string> ClaimsValues { get; init; } = [];
    }
}
