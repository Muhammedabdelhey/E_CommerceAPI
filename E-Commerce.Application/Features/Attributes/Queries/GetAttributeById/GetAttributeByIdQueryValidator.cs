namespace E_Commerce.Application.Features.Attributes.Queries.GetAttributeById
{
    public class GetAttributeByIdQueryValidator : AbstractValidator<GetAttributeByIdQuery>
    {
        public GetAttributeByIdQueryValidator()
        {
            RuleFor(v => v.guid)
                .SetValidator(new GuidValidator());
        }
    }
}
