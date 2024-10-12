﻿using E_Commerce.Application.Models;
using E_Commerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_Commerce.Application.Common.Services
{
    public class JwtService(JwtOptions _jwtOptions, UserManager<User> _userManager, RoleManager<IdentityRole> _roleManager)
    {
        public async Task<JwtSecurityToken> GenerateToken(User user)
        {
            var claims = await GetClaims(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SigningKey)),
                    SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtOptions.Lifetime)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = (JwtSecurityToken)token;
            return accessToken;
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
                        claims.Add(new Claim(typeof(Permissions).Name.ToLower(), claim.Value));
                    }
                }
            }
        }

        private async Task AddUserCustomClaims(List<Claim> claims, User user)
        {
            var userCustomClaims = await _userManager.GetClaimsAsync(user);
            foreach (var claim in userCustomClaims)
            {
                claims.Add(new Claim(typeof(Permissions).Name.ToLower(), claim.Value));
            }
        }
    }
}