namespace E_Commerce.Application.Features.User_Management.Commands.UserRoles
{
    public class UserRolesCommandValidator : AbstractValidator<UserRolesCommand>
    {

        public UserRolesCommandValidator(UserExistenceValidator userExistence, RoleExistenceValidator roleExistence)
        {

            RuleFor(v => v.UserId)
                .SetValidator(userExistence);

            RuleFor(v => v.RolesNames)
                .NotEmpty();

            RuleForEach(v => v.RolesNames)
                .SetValidator(roleExistence);
        }

    }
}
