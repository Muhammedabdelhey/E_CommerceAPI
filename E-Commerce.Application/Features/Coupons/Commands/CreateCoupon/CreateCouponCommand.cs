namespace E_Commerce.Application.Features.Coupons.Commands.CreateCoupon
{
    public record CreateCouponCommand : IRequest<CouponDto>
    {
        public double DiscountValue { get; init; }
        public DiscountType DiscountType { get; init; }
        public DateTimeOffset StartDate { get; init; }
        public DateTimeOffset EndDate { get; init; }
        public int CouponLength { get; init; } = 8;
        public int MaxNumberOfUses { get; init; }
        public int UsageLimitPerUser { get; init; }
    }
}
