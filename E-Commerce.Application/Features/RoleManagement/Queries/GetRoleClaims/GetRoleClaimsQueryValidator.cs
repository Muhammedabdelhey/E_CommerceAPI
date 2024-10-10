namespace E_Commerce.Application.Features.RoleManagement.Queries.GetRoleClaims
{
    public class GetRoleClaimsQueryValidator : AbstractValidator<GetRoleClaimsQuery>
    {
        public GetRoleClaimsQueryValidator()
        {
            RuleFor(v => v.roleId)
                .SetValidator(new GuidValidator());
        }
    }
}
