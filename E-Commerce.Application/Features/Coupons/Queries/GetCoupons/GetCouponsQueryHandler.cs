
namespace E_Commerce.Application.Features.Coupons.Queries.GetCoupons
{
    public class GetCouponsQueryHandler : IRequestHandler<GetCouponsQuery, IEnumerable<CouponDto>>
    {
        private readonly IBaseRepository<Coupon> _couponRepository;
        private readonly IMapper _mapper;
        public GetCouponsQueryHandler(IBaseRepository<Coupon> couponRepository, IMapper mapper)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CouponDto>> Handle(GetCouponsQuery request, CancellationToken cancellationToken)
        {
            var coupons = await _couponRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<CouponDto>>(coupons);
        }
    }
}
