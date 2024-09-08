namespace E_Commerce.Application.Common.Validator
{
    public class GuidValidator : AbstractValidator<string>
    {
        /// <summary>
        /// check this is valid guid and not empty
        /// </summary>
        public GuidValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .Must(IsValidGuid).WithMessage("Invalid GUID format");
        }
        private bool IsValidGuid(string id)
        {
            return Guid.TryParse(id, out _);
        }
    }
}
