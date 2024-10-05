namespace E_Commerce.Application.Features.Coupons.Commands.CreateCoupon
{
    public record CreateCouponCommand : IRequest<CouponDto>
    {
        public decimal DiscountValue { get; set; }
        public DiscountType DiscountType { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int CouponLength { get; set; } = 8;
        public int MaxNumberOfUses { get; set; }
        public int UsageLimitPerUser { get; set; }
    }
}
