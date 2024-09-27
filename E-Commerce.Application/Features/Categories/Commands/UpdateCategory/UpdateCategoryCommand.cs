namespace E_Commerce.Application.Features.Categories.Commands.UpdateCategory
{
    public record UpdateCategoryCommand : IRequest<CategoryDto>
    {
        public string guid { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public IFormFile? Image { get; init; }
        public string? ParentId { get; init; }
        public List<string?> AttributeIds { get; init; } = [];

    }
}
