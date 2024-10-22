using E_Commerce.Application.Models;
using E_Commerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace E_Commerce.Application.Common.Services
{
    public class JwtService
    {
        private readonly IOptions<JwtOptions> _jwtOptions;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IBaseRepository<UserRefreshToken> _refreshTokenRepository;
        public JwtService(IOptions<JwtOptions> jwtOptions, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IBaseRepository<UserRefreshToken> refreshTokenRepository)
        {
            _jwtOptions = jwtOptions;
            _userManager = userManager;
            _roleManager = roleManager;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<JwtSecurityToken> GenerateTokenAsync(string userId)
        {
            var user =await _userManager.FindByIdAsync(userId);
            var claims = await GetClaims(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = _jwtOptions.Value.Issuer,
                Audience = _jwtOptions.Value.Audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.SigningKey)),
                    SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtOptions.Value.Lifetime)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = (JwtSecurityToken)token;
            return accessToken;
        }

        public async Task<string> GenerateRefreshToken(string userId,string token,CancellationToken cancellationToken)
        {
            var randomNumber = new byte[32];
            var generator = RandomNumberGenerator.Create();
            generator.GetBytes(randomNumber);
            var rtoken = Convert.ToBase64String(randomNumber);
            UserRefreshToken refreshToken = new()
            {
                Token = token,
                RefreshToken = rtoken,
                UserId= userId,
                CreatedAt = DateTime.UtcNow,
            };
            await _refreshTokenRepository.AddAsync(refreshToken,cancellationToken);
            return rtoken;
        }

        public async Task<IEnumerable<Claim>> GetClaims(User user)
        {
            List<Claim> claims = new List<Claim>();

            AddBasicUserClaims(claims, user);

            await AddRoleClaims(claims, user);

            await AddUserCustomClaims(claims, user);

            return claims;
        }

        private void AddBasicUserClaims(List<Claim> claims, User user)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.GivenName, user.UserName));
        }

        private async Task AddRoleClaims(List<Claim> claims, User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                // Add Role
                claims.Add(new Claim(ClaimTypes.Role, role));
                // Retrieve the role object by its name
                var identityRole = await _roleManager.FindByNameAsync(role);
                if (identityRole != null)
                {
                    // Add Role Claims
                    var roleClaims = await _roleManager.GetClaimsAsync(identityRole);
                    foreach (var claim in roleClaims)
                    {
                        claims.Add(new Claim(typeof(Permissions).Name, claim.Value));
                    }
                }
            }
        }

        private async Task AddUserCustomClaims(List<Claim> claims, User user)
        {
            var userCustomClaims = await _userManager.GetClaimsAsync(user);
            foreach (var claim in userCustomClaims)
            {
                claims.Add(new Claim(typeof(Permissions).Name, claim.Value));
            }
        }
    }
}
