namespace E_Commerce.Application.Features.Coupons.Commands.DeleteCoupon
{
    public class DeleteCouponQueryValidator : AbstractValidator<DeleteCouponQuery>
    {
        public DeleteCouponQueryValidator(EntityExistenceValidator<Coupon> couponExistenceValidator)
        {
            RuleFor(v => v.guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.guid)
                        .SetValidator(couponExistenceValidator);
                });
        }
    }
}
