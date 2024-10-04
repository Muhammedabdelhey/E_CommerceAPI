namespace E_Commerce.Application.Features.Coupons.Queries.GetActiveCoupons
{
    public record GetActiveCouponsQuery : IRequest<IEnumerable<CouponDto>>;
}
