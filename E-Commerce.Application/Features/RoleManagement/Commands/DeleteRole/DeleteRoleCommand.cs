using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Features.RoleManagement.Commands.DeleteRole
{
    public record DeleteRoleCommand(string Id) : IRequest<IdentityRole>;
}
