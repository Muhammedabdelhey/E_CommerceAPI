namespace E_Commerce.Application.Features.Coupons.Commands
{
    public class CreateCouponCommandValidator : AbstractValidator<CreateCouponCommand>
    {
        public CreateCouponCommandValidator()
        {
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

            RuleFor(v => v.CouponLength)
                .Must(v => v >= 6 && v <= 16)
                .WithMessage("Coupon length must be between 6 and 16 characters.");

            RuleFor(v => v.MaxNumberOfUses)
                .GreaterThan(0);

            RuleFor(v => v.UsageLimitPerUser)
                .GreaterThan(0);

        }
    }
}
