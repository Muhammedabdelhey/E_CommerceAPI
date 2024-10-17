namespace E_Commerce.Application.Features.Attributes.Commands.DeleteAttribute
{
    public class DeleteAttributeCommandValidator : AbstractValidator<DeleteAttributeCommand>
    {
        public DeleteAttributeCommandValidator(EntityExistenceValidator<Attribute> attributeExistenceValidator)
        {
            RuleFor(v => v.Guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.Guid)
                        .SetValidator(attributeExistenceValidator);
                });
        }
    }
}
