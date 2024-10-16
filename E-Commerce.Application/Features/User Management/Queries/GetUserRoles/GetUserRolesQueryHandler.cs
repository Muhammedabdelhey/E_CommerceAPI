using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Features.User_Management.Queries.GetUserRoles
{
    public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, IEnumerable<string>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public GetUserRolesQueryHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<string>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId)
                ?? throw new NotFoundException($"User With ID: {request.UserId} Not Exist");
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }
    }
}
