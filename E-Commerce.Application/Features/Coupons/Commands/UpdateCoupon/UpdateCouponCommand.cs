namespace E_Commerce.Application.Features.Coupons.Commands.UpdateCoupon
{
    public record UpdateCouponCommand : IRequest<CouponDto>
    {
        public string Guid { get; init; } = string.Empty;
        public double DiscountValue { get; init; }
        public DiscountType DiscountType { get; init; }
        public DateTimeOffset StartDate { get; init; }
        public DateTimeOffset EndDate { get; init; }
        public int MaxNumberOfUses { get; init; }
        public int UsageLimitPerUser { get; init; }
        public bool IsActive { get; init; }

    }
}
