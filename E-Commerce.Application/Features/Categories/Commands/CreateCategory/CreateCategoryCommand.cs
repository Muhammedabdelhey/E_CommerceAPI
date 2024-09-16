using Microsoft.AspNetCore.Http;

namespace E_Commerce.Application.Features.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand : IRequest<Category>
    {
        public string? Name { get; init; } 
        public IFormFile? Image { get; init; }

        public string? ParentId { get; set; }
    }
}
