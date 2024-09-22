namespace E_Commerce.Application.Features.Attributes.Commands.UpdateAttribute
{
    public class UpdateAttributeCommandValidator : AbstractValidator<UpdateAttributeCommand>
    {
        public UpdateAttributeCommandValidator()
        {
            RuleFor(v => v.Guid)
                .NotEmpty();

            RuleFor(v => v.Name)
                .ValidateString(50);
        }
    }
}
