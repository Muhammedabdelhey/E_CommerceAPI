﻿namespace E_Commerce.Application.Features.Attributes.Queries.GetAttributeById
{
    public class GetAttributeByIdQueryValidator : AbstractValidator<GetAttributeByIdQuery>
    {
        public GetAttributeByIdQueryValidator(EntityExistenceValidator<Attribute> attributeExistenceValidator)
        {
            RuleFor(v => v.guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.guid)
                        .SetValidator(attributeExistenceValidator);
                });
        }
    }
}
