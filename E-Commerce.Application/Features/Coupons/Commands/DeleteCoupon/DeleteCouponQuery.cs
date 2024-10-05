namespace E_Commerce.Application.Features.Coupons.Commands.DeleteCoupon
{
    public record DeleteCouponQuery(string guid) : IRequest<CouponDto>;

}
