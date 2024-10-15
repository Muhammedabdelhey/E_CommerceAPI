namespace E_Commerce.Application.Features.User_Management.Commands.UserRoles
{
    public record UserRolesCommand : IRequest<IEnumerable<string>>
    {
        public string UserId { get; init; } = string.Empty;
        public List<string> RolesNames { get; init; } = [];

    }
}
