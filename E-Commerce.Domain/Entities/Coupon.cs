using E_Commerce.Domain.Comman;

namespace E_Commerce.Domain.Entities
{
    public class Coupon : BaseEntity
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int NumberOfUsing { get; set; } = 0;
        public int MaxNumberOfUses { get; set; }
        public decimal DiscountValue { get; set; }
        public DiscountType DiscountType { get; set; }
        public bool IsActive { get; set; } = true;
        public int UsageLimitPerUser { get; set; }
        public string CouponCode { get; set; } = string.Empty;
    }
    public enum DiscountType
    {
        Percentage,
        FixedAmount
    }
}
