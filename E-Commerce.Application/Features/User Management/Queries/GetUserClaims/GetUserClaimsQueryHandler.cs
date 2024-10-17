using E_Commerce.Application.Features.RoleManagement;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Features.User_Management.Queries.GetUserClaims
{
    public class GetUserClaimsQueryHandler : IRequestHandler<GetUserClaimsQuery, IEnumerable<PermissionsDto>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public GetUserClaimsQueryHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PermissionsDto>> Handle(GetUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId)
                ?? throw new NotFoundException("User", request.UserId);
            var claims = await _userManager.GetClaimsAsync(user);
            return _mapper.Map<IEnumerable<PermissionsDto>>(claims);
        }
    }
}
