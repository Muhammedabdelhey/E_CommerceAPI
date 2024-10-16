namespace E_Commerce.Application.Features.User_Management.Queries.GetUsers
{
    public record GetUsersQuery : IRequest<IEnumerable<UserDto>>;
}
