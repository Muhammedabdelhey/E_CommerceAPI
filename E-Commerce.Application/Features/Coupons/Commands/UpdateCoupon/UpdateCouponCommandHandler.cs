
namespace E_Commerce.Application.Features.Coupons.Commands.UpdateCoupon
{
    public class UpdateCouponCommandHandler : IRequestHandler<UpdateCouponCommand, CouponDto>
    {
        private readonly IBaseRepository<Coupon> _couponRepository;
        private readonly IMapper _mapper;
        public UpdateCouponCommandHandler(IBaseRepository<Coupon> couponRepository, IMapper mapper)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
        }

        public async Task<CouponDto> Handle(UpdateCouponCommand request, CancellationToken cancellationToken)
        {
            var coupon = await _couponRepository.GetByIdAsync(Guid.Parse(request.guid), cancellationToken)
                ?? throw new NotFoundException("Coupon", request.guid);
            coupon.StartDate = request.StartDate;
            coupon.EndDate = request.EndDate;
            coupon.DiscountType = request.DiscountType;
            coupon.DiscountValue = request.DiscountValue;
            coupon.MaxNumberOfUses = request.MaxNumberOfUses;
            coupon.UsageLimitPerUser = request.UsageLimitPerUser;
            coupon.IsActive = request.IsActive;
            coupon = await _couponRepository.UpdateAsync(coupon, cancellationToken);
            return _mapper.Map<CouponDto>(coupon);
        }
    }
}
