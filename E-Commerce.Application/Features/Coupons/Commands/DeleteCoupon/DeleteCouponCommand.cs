namespace E_Commerce.Application.Features.Coupons.Commands.DeleteCoupon
{
    public record DeleteCouponCommand(string Guid) : IRequest<Unit>;

}
