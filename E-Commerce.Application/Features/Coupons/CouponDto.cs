namespace E_Commerce.Application.Features.Coupons
{
    public class CouponDto
    {
        public string Id { get; set; }
        public string CouponCode { get; set; } = string.Empty;
        public decimal DiscountValue { get; set; }
        public DiscountType DiscountType { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int NumberOfUsing { get; set; }
        public int MaxNumberOfUses { get; set; }
        public int UsageLimitPerUser { get; set; }
        public bool IsActive { get; set; }

        private class CouponMapping : Profile
        {
            public CouponMapping()
            {
                CreateMap<Coupon, CouponDto>();
            }
        }
    }
}
