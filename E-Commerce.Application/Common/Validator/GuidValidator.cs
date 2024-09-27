namespace E_Commerce.Application.Common.Validator
{
    public class GuidValidator : AbstractValidator<string?>
    {
        /// <summary>
        /// check this is valid Guid and not empty
        /// </summary>
        public GuidValidator()
        {
            RuleFor(x => x)
                .Must(x => Guid.TryParse(x, out _))
                .WithMessage("Invalid GUID Format");
        }
    }
}
