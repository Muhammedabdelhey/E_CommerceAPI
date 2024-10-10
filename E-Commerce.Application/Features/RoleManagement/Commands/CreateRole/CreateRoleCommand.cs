using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Features.RoleManagement.Commands.CreateRole
{
    public record CreateRoleCommand(string name) : IRequest<IdentityRole>;

}
