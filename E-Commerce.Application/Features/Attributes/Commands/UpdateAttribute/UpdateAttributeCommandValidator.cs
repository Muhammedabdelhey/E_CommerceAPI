namespace E_Commerce.Application.Features.Attributes.Commands.UpdateAttribute
{
    public class UpdateAttributeCommandValidator : AbstractValidator<UpdateAttributeCommand>
    {
        public UpdateAttributeCommandValidator(EntityExistenceValidator<Attribute> attributeExistenceValidator)
        {
            RuleFor(v => v.Guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .SetValidator(attributeExistenceValidator);

            RuleFor(v => v.Name)
                .ValidateString(50);
        }
    }
}
