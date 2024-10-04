namespace E_Commerce.Application.Features.Coupons.Queries.GetCouponById
{
    public class GetCouponByIdQueryValidator : AbstractValidator<GetCouponByIdQuery>
    {
        public GetCouponByIdQueryValidator(EntityExistenceValidator<Coupon> couponExistenceValidator)
        {
            RuleFor(v => v.guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .SetValidator(couponExistenceValidator);
        }
    }
}
