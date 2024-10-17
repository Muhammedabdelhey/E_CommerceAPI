namespace E_Commerce.Application.Features.Coupons.Queries.GetCouponById
{
    public class GetCouponByIdQueryHandler : IRequestHandler<GetCouponByIdQuery, CouponDto>
    {
        private readonly IBaseRepository<Coupon> _CouponRepository;
        private readonly IMapper _Mapper;

        public GetCouponByIdQueryHandler(IBaseRepository<Coupon> couponRepository, IMapper mapper)
        {
            _Mapper = mapper;
            _CouponRepository = couponRepository;
        }

        public async Task<CouponDto> Handle(GetCouponByIdQuery request, CancellationToken cancellationToken)
        {
            var coupon = await _CouponRepository.GetByIdAsync(Guid.Parse(request.Guid), cancellationToken)
                ?? throw new NotFoundException("Coupon", request.Guid);
            return _Mapper.Map<CouponDto>(coupon);
        }
    }
}
