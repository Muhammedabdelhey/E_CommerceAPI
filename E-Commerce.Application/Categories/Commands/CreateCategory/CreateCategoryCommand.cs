using Microsoft.AspNetCore.Http;

namespace E_Commerce.Application.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand : IRequest<Category>
    {
        public string Name { get; init; } = string.Empty;
        public IFormFile? Image { get; init; }

        public string? ParentId { get; set; }
    }
}
