namespace E_Commerce.Application.Features.Coupons.Queries.GetActiveCoupons
{
    public class GetActiveCouponsQueryHandler : IRequestHandler<GetActiveCouponsQuery, IEnumerable<CouponDto>>
    {
        private readonly IBaseRepository<Coupon> _couponRepository;
        private readonly IMapper _mapper;
        public GetActiveCouponsQueryHandler(IBaseRepository<Coupon> couponRepository, IMapper mapper)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CouponDto>> Handle(GetActiveCouponsQuery request, CancellationToken cancellationToken)
        {
            var coupons = await _couponRepository.GetByAsync(c => c.IsActive == true, cancellationToken);
            return _mapper.Map<IEnumerable<CouponDto>>(coupons);
        }
    }
}
