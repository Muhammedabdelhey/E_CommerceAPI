using E_Commerce.Application.Features.RoleManagement;

namespace E_Commerce.Application.Features.User_Management.Queries.GetUserClaims
{
    public record GetUserClaimsQuery(string UserId) : IRequest<IEnumerable<PermissionsDto>>;
}
