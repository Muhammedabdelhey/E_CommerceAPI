namespace E_Commerce.Application.Features.Authentication.Commands.SignIn
{
    public class SignInCommand : IRequest<TokenObj>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
