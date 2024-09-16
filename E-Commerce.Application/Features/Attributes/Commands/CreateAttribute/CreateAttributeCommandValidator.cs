namespace E_Commerce.Application.Features.Attributes.Commands.CreateAttribute
{
    public class CreateAttributeCommandValidator : AbstractValidator<CreateAttributeCommand>
    {
        public CreateAttributeCommandValidator()
        {
            RuleFor(v => v.Name)
                .ValidateString(50);
        }
    }
}
