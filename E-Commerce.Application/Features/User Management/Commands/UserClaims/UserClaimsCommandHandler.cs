using E_Commerce.Application.Features.RoleManagement;
using E_Commerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Security.Claims;

namespace E_Commerce.Application.Features.User_Management.Commands.UserClaims
{
    public class UserClaimsCommandHandler : IRequestHandler<UserClaimsCommand, IEnumerable<PermissionsDto>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public UserClaimsCommandHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionsDto>> Handle(UserClaimsCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId)
                ?? throw new NotFoundException("User", request.UserId);

            var existingClaims = await _userManager.GetClaimsAsync(user);
            var existingClaimValues = existingClaims.Select(c => c.Value).ToList();

            var claimsToRemove = existingClaimValues.Except(request.ClaimsValues);
            foreach (var claimValue in claimsToRemove)
            {
                var claim = existingClaims.FirstOrDefault(c => c.Value == claimValue);
                if (claim != null)
                {
                    await _userManager.RemoveClaimAsync(user,claim);
                }
            }

            var claimsToAdd = request.ClaimsValues.Except(existingClaimValues);
            foreach (var claimValue in claimsToAdd)
            {
                var newClaim = new Claim(typeof(Permissions).Name, claimValue);
                await _userManager.AddClaimAsync(user,newClaim);
            }
            var updatedClaims = await _userManager.GetClaimsAsync(user);
            return _mapper.Map<IEnumerable<PermissionsDto>>(updatedClaims);
        }
    }
}
