namespace E_Commerce.Application.Features.User_Management.Commands.UserClaims
{
    public class UserClaimsCommandValidator : AbstractValidator<UserClaimsCommand>
    {
        public UserClaimsCommandValidator(UserExistenceValidator userExistence)
        {
            RuleFor(v => v.UserId)
                .SetValidator(userExistence);

            RuleFor(v => v.ClaimsValues)
                .NotEmpty();

            RuleForEach(v => v.ClaimsValues)
                .SetValidator(new PermissionValidator());
        }
    }
}
