namespace E_Commerce.Application.Features.Coupons.Commands.DeleteCoupon
{
    public class DeleteCouponQueryValidator : AbstractValidator<DeleteCouponCommand>
    {
        public DeleteCouponQueryValidator(EntityExistenceValidator<Coupon> couponExistenceValidator)
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
