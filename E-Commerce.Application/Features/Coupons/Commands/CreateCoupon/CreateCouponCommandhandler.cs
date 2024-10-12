namespace E_Commerce.Application.Features.Coupons.Commands.CreateCoupon
{
    public class CreateCouponCommandhandler : IRequestHandler<CreateCouponCommand, CouponDto>
    {
        private readonly IBaseRepository<Coupon> _couponRepository;
        private readonly IMapper _mapper;
        private readonly Random _random = new ();
        public CreateCouponCommandhandler(IBaseRepository<Coupon> couponRepository, IMapper mapper)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
        }

        public async Task<CouponDto> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
        {
            Coupon coupon = new()
            {
                CouponCode = await GenerateCouponCode(request.CouponLength, cancellationToken),
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                DiscountValue = request.DiscountValue,
                DiscountType = request.DiscountType,
                MaxNumberOfUses = request.MaxNumberOfUses,
                UsageLimitPerUser = request.UsageLimitPerUser
            };
            coupon = await _couponRepository.AddAsync(coupon, cancellationToken);
            return _mapper.Map<CouponDto>(coupon);
        }
        public async Task<string> GenerateCouponCode(int length, CancellationToken cancellationToken)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            while (true)
            {
                var code = new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[_random.Next(s.Length)]).ToArray());
                var existingCoupons = await _couponRepository.GetByAsync(c => c.CouponCode == code, cancellationToken);
                if (!existingCoupons.Any())
                {
                    return code;
                }
            }
        }
    }
}
