namespace E_Commerce.Application.Features.Authentication
{
    public class TokenObj
    {
        public string AccessToken { get; set; } =string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpireOn { get; set; }

    }
}
