namespace E_Commerce.Application.Features.Attributes.Queries.GetAttributeById
{
    public class GetAttributeByIdQueryValidator : AbstractValidator<GetAttributeByIdQuery>
    {
        public GetAttributeByIdQueryValidator(EntityExistenceValidator<Attribute> attributeExistenceValidator)
        {
            RuleFor(v => v.guid)
                .SetValidator(new GuidValidator())
                .SetValidator(attributeExistenceValidator);
    }
    }
}
