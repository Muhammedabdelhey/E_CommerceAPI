namespace E_Commerce.Domain.Entities
{
    public class UserRefreshToken : BaseEntity
    {
        public string Token {  get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public bool IsUsed { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public string UserId {  get; set; }
        [ForeignKey(nameof(UserId))]
        public User user { get; set; }
    }
}
