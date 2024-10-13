namespace E_Commerce.Application.Features.Authentication.Commands.SignUp
{
    public class SignUpCommand : IRequest<TokenObj>
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; } 
    }
}
