namespace E_Commerce.Application.Common.Validator
{
    public class ImageValidator : AbstractValidator<IFormFile?>
    {
        private readonly string AllowedExtensions = ".png,.jpg,.jpeg";
        public ImageValidator()
        {
            RuleFor(v => v)
                .Must(IsImage)
                .WithMessage($"Only the following extensions are allowed:{AllowedExtensions}");
        }
        private bool IsImage(IFormFile? image)
        {
            string extension = Path.GetExtension(image.FileName);
            return AllowedExtensions.Split(',').Contains(extension, StringComparer.OrdinalIgnoreCase);

        }
    }
}
