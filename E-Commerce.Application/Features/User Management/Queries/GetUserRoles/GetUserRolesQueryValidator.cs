namespace E_Commerce.Application.Features.User_Management.Queries.GetUserRoles
{
    public class GetUserRolesQueryValidator : AbstractValidator<GetUserRolesQuery>
    {
        public GetUserRolesQueryValidator(UserExistenceValidator userExistenceValidator)
        {
            RuleFor(v => v.UserId)
                .SetValidator(userExistenceValidator);
        }
    }
}
