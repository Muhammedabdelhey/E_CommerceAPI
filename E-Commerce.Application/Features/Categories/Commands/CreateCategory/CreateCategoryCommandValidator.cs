using Microsoft.AspNetCore.Http;

namespace E_Commerce.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly IBaseRepository<Attribute> _attributeRepository;
        public CreateCategoryCommandValidator(IBaseRepository<Attribute> attributeRepository)
        {
            _attributeRepository = attributeRepository;
            RuleFor(v => v.Name)
                .ValidateString(50);

            RuleFor(v => v.Image)
                .SetValidator(new ImageValidator());

            RuleFor(v => v.AttributeIds)
                .NotEmpty().WithMessage("AttributeIds cannot be empty.")
                .MustAsync(ExistInDatabase).WithMessage("One or more AttributeIds do not exist.");
        }



        private async Task<bool> ExistInDatabase(IEnumerable<Guid> attributeIds, CancellationToken cancellationToken)
        {
            foreach (var attributeId in attributeIds)
            {
                if (await _attributeRepository.GetByIdAsync(attributeId, cancellationToken) is null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
