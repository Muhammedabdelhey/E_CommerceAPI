
using E_Commerce.Application.Common.Services;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace E_Commerce.Application.Features.Authentication.Commands.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, TokenObj>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly JwtService _jwtService;
        public SignInCommandHandler(SignInManager<User> signInManager, UserManager<User> userManager, JwtService jwtService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<TokenObj> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user =await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new ValidationException("Email Or Password Not Correct");

            var result =await  _signInManager.CheckPasswordSignInAsync(user, request.Password,false);
            if (!result.Succeeded)
                throw new ValidationException("Email Or Password Not Correct");

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
