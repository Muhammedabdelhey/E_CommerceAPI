namespace E_Commerce.Application.Attributes.Commands.UpdateAttribute
{
    public class UpdateAttributeCommandValidator : AbstractValidator<UpdateAttributeCommand>
    {
        public UpdateAttributeCommandValidator()
        {
            RuleFor(v => v.Guid)
                .SetValidator(new GuidValidator());
            RuleFor(v => v.Name)
                .ValidateString(50);
        }
    }
}
