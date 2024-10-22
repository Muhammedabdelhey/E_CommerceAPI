namespace E_Commerce.Application.Features.Authentication.Commands.RefreshToken
{
    public record RefreshTokenCommand : IRequest<TokenObj>
    {
        public string Token { get; init; }
        public string RefreshToken { get; init; }

    }
}
