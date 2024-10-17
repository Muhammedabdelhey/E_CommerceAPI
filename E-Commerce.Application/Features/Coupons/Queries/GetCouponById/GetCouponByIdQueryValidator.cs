namespace E_Commerce.Application.Features.Coupons.Queries.GetCouponById
{
    public class GetCouponByIdQueryValidator : AbstractValidator<GetCouponByIdQuery>
    {
        public GetCouponByIdQueryValidator(EntityExistenceValidator<Coupon> couponExistenceValidator)
        {
            RuleFor(v => v.Guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.Guid)
                        .SetValidator(couponExistenceValidator);
                });
        }
    }
}
