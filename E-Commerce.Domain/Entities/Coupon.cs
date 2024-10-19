namespace E_Commerce.Domain.Entities
{
    public class Coupon : BaseEntity
    {
        public string CouponCode { get; set; } = string.Empty;
        public double DiscountValue { get; set; }
        public DiscountType DiscountType { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int NumberOfUsing { get; set; } = 0;
        public int MaxNumberOfUses { get; set; }
        public int UsageLimitPerUser { get; set; }
        public bool IsActive { get; set; } = true;
    }
    public enum DiscountType
    {
        Percentage = 1,
        FixedAmount = 2
    }
}
