namespace E_Commerce.Application.Features.Coupons.Queries.GetCouponById
{
    public record GetCouponByIdQuery(string Guid) : IRequest<CouponDto>;

}
