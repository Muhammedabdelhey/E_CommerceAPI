namespace E_Commerce.Application.Features.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand : IRequest<CategoryDto>
    {
        public string? Name { get; init; }
        public IFormFile? Image { get; init; }

        public string? ParentId { get; set; }
    }
}
