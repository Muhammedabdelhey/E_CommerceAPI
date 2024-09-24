namespace E_Commerce.Application.Features.Categories.Commands.UpdateCategory
{
    public record UpdateCategoryCommand : IRequest<CategoryDto>
    {
        public Guid guid { get; init; }
        public string Name { get; init; } = string.Empty;
        public IFormFile? Image { get; init; }
        public Guid? ParentId { get; set; }
        public List<Guid?> AttributeIds { get; set; } = new List<Guid?>();

    }
}
