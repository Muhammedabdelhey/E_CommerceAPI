namespace E_Commerce.Application.Attributes.Queries.GetAttributeById
{
    public class GetAttributeByIdValidator : AbstractValidator<GetAttributeByIdQuery>
    {
        public GetAttributeByIdValidator()
        {
            RuleFor(v => v.guid)
                .SetValidator(new GuidValidator());
        }
    }
}
