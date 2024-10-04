using E_Commerce.Domain.Comman;

namespace E_Commerce.Domain.Entities
{
    public class CouponUsage : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid CouponId { get; set; }
        [ForeignKey("CouponId")]
        public Coupon Coupon { get; set; }
        public int TimesUsed { get; set; }
    }
}
