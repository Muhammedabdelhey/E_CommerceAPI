namespace E_Commerce.Application.Features.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand : IRequest<CategoryDto>
    {
        public string Name { get; init; } = string.Empty;
        public IFormFile? Image { get; init; }
        public string? ParentId { get; init; }
        public List<string?> AttributeIds { get; init; } = [];
    }
}

