using E_Commerce.Application.Common.Services;
using E_Commerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace E_Commerce.Application.Features.Authentication.Commands.SignUp
{
    public class SignupCommandHandler : IRequestHandler<SignUpCommand, TokenObj>
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtService _jwtService;
        public SignupCommandHandler(UserManager<User> userManager, JwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<TokenObj> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            User user = new()
            {
                UserName = request.UserName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new ValidationException(result.Errors);

            var role = _userManager.AddToRoleAsync(user, Roles.User.ToString()).Result;
            if (!role.Succeeded)
                throw new ValidationException(role.Errors);

            var token = await _jwtService.GenerateTokenAsync(user);
            return new TokenObj
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                ExpireOn = token.ValidTo,
                RefreshToken = ""
            };
        }
    }
}

