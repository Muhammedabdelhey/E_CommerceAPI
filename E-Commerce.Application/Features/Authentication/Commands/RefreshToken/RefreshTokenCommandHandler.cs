
using E_Commerce.Application.Common.Services;
using E_Commerce.Domain.Entities;
using MediatR;
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
            var token = await CheckRefreshTokenValidation(request, userId, cancellationToken);
            if (token == null)
                throw new NotFoundException("Token or Refresh Token not valid");

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

        private async Task<UserRefreshToken?> CheckRefreshTokenValidation(RefreshTokenCommand command,
            string userId, CancellationToken cancellationToken)
        {
            return (await _refreshTokenRepository.GetByAsync(
                t => t.RefreshToken == command.RefreshToken &&
                     t.Token == command.Token &&
                     !t.IsUsed &&
                     t.UserId == userId,
                cancellationToken)).FirstOrDefault();
        }
    }
}
