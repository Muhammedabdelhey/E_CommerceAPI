namespace E_Commerce.Application.Features.Coupons.Commands.UpdateCoupon
{
    public class UpdateCouponCommandValidator : AbstractValidator<UpdateCouponCommand>
    {
        public UpdateCouponCommandValidator(EntityExistenceValidator<Coupon> couponExistenceValidator)
        {
            RuleFor(v => v.guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.guid)
                        .SetValidator(couponExistenceValidator);
                });

            RuleFor(v => v.DiscountValue)
                 .GreaterThan(0);

            RuleFor(v => v.DiscountType)
                .IsInEnum();

            RuleFor(v => v.StartDate)
                .NotEmpty()
                .Must(v => v >= DateTimeOffset.Now.Date);

            RuleFor(v => v.EndDate)
                .NotEmpty();

            RuleFor(v => v)
                .Must(v => v.EndDate > v.StartDate)
                .WithMessage("The End Date must be after the Start Date.");

            RuleFor(v => v.IsActive)
                .Must(v => v == true || v == false)
                .WithMessage("IsActive must be either true or false.");

            RuleFor(v => v.MaxNumberOfUses)
                .GreaterThan(0);

            RuleFor(v => v.UsageLimitPerUser)
                .GreaterThan(0);

        }
    }
}
