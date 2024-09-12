namespace E_Commerce.Application.Attributes.Commands.DeleteAttribute
{
    public class DeleteAttributeCommandValidator : AbstractValidator<DeleteAttributeCommand>
    {
        public DeleteAttributeCommandValidator()
        {
            RuleFor(v => v.guid)
                .SetValidator(new GuidValidator());
        }
    }
}
