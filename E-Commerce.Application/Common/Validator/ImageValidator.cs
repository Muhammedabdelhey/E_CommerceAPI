namespace E_Commerce.Application.Common.Validator
{
    public class ImageValidator : AbstractValidator<IFormFile>
    {
        string AllowedExtensions = ".png,.jpg,.jpeg";
        public ImageValidator()
        {
            RuleFor(v => v)
                .Must(isImage)
                .WithMessage($"Only the following extensions are allowed:{AllowedExtensions}");
        }
        private bool isImage(IFormFile image)
        {

            if (image != null)
            {
                string extension = Path.GetExtension(image.FileName);
                if (!AllowedExtensions.Split(',').Contains(extension, StringComparer.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
