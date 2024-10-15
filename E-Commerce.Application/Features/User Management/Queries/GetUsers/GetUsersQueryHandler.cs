
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Features.User_Management.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
    {
        private readonly UserManager<User> _userManager;
        public GetUsersQueryHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userManager.Users.ToListAsync(cancellationToken);
        }
    }
}
