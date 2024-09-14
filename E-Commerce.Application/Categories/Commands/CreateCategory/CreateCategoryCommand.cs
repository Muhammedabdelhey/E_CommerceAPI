namespace E_Commerce.Application.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand : IRequest<Category>
    {
        public string Name { get; init; } = string.Empty;
        public string? Image { get; init; }

        public string? ParentId { get; set; }
    }
}
