using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Features.User_Management.Queries.GetUserRoles
{
    public record GetUserRolesQuery(string UserId) : IRequest<IEnumerable<string>>;
}
