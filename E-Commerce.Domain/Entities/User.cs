using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Domain.Entities
{
    public class User : IdentityUser
    {
        public string? Address { get; set; } = string.Empty;
    }
}
