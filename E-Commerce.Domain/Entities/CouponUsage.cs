namespace E_Commerce.Domain.Entities
{
    public class CouponUsage : BaseEntity
    {
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid CouponId { get; set; }
        [ForeignKey("CouponId")]
        public Coupon Coupon { get; set; }
        public int TimesUsed { get; set; }
    }
}
