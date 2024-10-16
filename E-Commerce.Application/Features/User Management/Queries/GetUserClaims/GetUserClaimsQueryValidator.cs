namespace E_Commerce.Application.Features.User_Management.Queries.GetUserClaims
{
    public class GetUserClaimsQueryValidator : AbstractValidator<GetUserClaimsQuery>
    {
        public GetUserClaimsQueryValidator(UserExistenceValidator userExistenceValidator)
        {
            RuleFor(v => v.UserId)
                .SetValidator(userExistenceValidator);
        }
    }
}
