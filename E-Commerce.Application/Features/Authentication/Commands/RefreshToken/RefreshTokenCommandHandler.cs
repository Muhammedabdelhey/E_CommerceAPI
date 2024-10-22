
using E_Commerce.Application.Common.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace E_Commerce.Application.Features.Authentication.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenObj>
    {
        private readonly IBaseRepository<UserRefreshToken> _refreshTokenRepository;
        private readonly JwtService _jwtService;
        public RefreshTokenCommandHandler(IBaseRepository<UserRefreshToken> refreshTokenRepository, JwtService jwtService)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _jwtService = jwtService;
        }

        public async Task<TokenObj> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            // get userId from token
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(request.Token);
            var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId);
            if (userIdClaim == null)
            {
                throw new NotFoundException("User ID not found in token");
            }
            var userId = userIdClaim.Value;
            var result = await _refreshTokenRepository.GetByAsync(t => t.RefreshToken == request.RefreshToken
            && t.Token == request.Token && t.IsUsed == false && t.UserId == userId);
            if (result.Count() == 0)
            {
                throw new NotFoundException("Token Or Refresh Token Not Valid");
            }

            var token = result.FirstOrDefault();
            var newAccessToken = await _jwtService.GenerateTokenAsync(userId);

            await _refreshTokenRepository.DeleteAsync(token);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken);
            return new TokenObj
            {
                AccessToken = accessToken,
                ExpireOn = newAccessToken.ValidTo,
                RefreshToken = await _jwtService.GenerateRefreshToken(userId, accessToken, cancellationToken)
            };
        }
    }
}
