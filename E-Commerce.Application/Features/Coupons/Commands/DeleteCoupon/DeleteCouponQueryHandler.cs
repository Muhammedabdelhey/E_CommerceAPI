namespace E_Commerce.Application.Features.Coupons.Commands.DeleteCoupon
{
    public class DeleteCouponQueryHandler : IRequestHandler<DeleteCouponQuery, CouponDto>
    {
        private readonly IBaseRepository<Coupon> _couponRepository;
        private readonly IMapper _mapper;

        public DeleteCouponQueryHandler(IBaseRepository<Coupon> couponRepository, IMapper mapper)
        {
            _mapper = mapper;
            _couponRepository = couponRepository;
        }

        public async Task<CouponDto> Handle(DeleteCouponQuery request, CancellationToken cancellationToken)
        {
            var coupon = await _couponRepository.GetByIdAsync(Guid.Parse(request.guid), cancellationToken)
                ?? throw new NotFoundException($"Coupon with Guid {request.guid} not found");
            coupon = await _couponRepository.DeleteAsync(coupon, cancellationToken);
            return _mapper.Map<CouponDto>(coupon);
        }
    }
}
