namespace E_Commerce.Application.Features.Coupons.Commands.DeleteCoupon
{
    public class DeleteCouponCommandHandler : IRequestHandler<DeleteCouponCommand, Unit>
    {
        private readonly IBaseRepository<Coupon> _couponRepository;

        public DeleteCouponCommandHandler(IBaseRepository<Coupon> couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public async Task<Unit> Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
        {
            var coupon = await _couponRepository.GetByIdAsync(Guid.Parse(request.Guid), cancellationToken)
                ?? throw new NotFoundException("Coupon", request.Guid);

            await _couponRepository.DeleteAsync(coupon, cancellationToken);
            return Unit.Value;
        }
    }
}
