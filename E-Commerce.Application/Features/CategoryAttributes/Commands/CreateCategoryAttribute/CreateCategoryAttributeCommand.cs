using System.ComponentModel;

namespace E_Commerce.Application.Features.CategoryAttributes.Commands.CreateCategoryAttribute
{
    public record CreateCategoryAttributeCommand : IRequest<CategoryAttribute>
    {
        public string CategoryId { get; init; }
        public string AttributeId { get; init; }
    }
}
