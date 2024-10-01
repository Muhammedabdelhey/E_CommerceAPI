namespace E_Commerce.Application.Features.Attributes.Commands.DeleteAttribute
{
    public class DeleteAttributeCommandValidator : AbstractValidator<DeleteAttributeCommand>
    {
        public DeleteAttributeCommandValidator(EntityExistenceValidator<Attribute> attributeExistenceValidator)
        {
            RuleFor(v => v.guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .SetValidator(attributeExistenceValidator);
        }
    }
}
