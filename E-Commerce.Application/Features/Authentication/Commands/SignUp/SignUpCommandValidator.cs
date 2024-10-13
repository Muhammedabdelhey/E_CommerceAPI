namespace E_Commerce.Application.Features.Authentication.Commands.SignUp
{
    public class SignupCommandValidator : AbstractValidator<SignUpCommand>
    {
        public SignupCommandValidator()
        {
            RuleFor(v => v.UserName)
                .NotEmpty();

            RuleFor(v => v.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(v => v.Password)
                .NotEmpty();

            When(v => !string.IsNullOrEmpty(v.PhoneNumber), () =>
            {
                RuleFor(v => v.PhoneNumber)
                    .Length(11)
                    .WithMessage("Phone number must be exactly 11 digits.")
                    .Matches(@"^\d{11}$")
                    .WithMessage("Phone number must contain only digits.");
            });
        }
    }
}
