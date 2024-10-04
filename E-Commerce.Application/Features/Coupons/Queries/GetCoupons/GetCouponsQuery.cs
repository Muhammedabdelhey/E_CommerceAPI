namespace E_Commerce.Application.Features.Coupons.Queries.GetCoupons
{
    public record GetCouponsQuery : IRequest<IEnumerable<CouponDto>>;
}
