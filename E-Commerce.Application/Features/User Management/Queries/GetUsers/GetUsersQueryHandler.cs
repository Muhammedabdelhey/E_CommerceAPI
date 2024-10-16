
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Features.User_Management.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public GetUsersQueryHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
