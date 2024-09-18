﻿namespace E_Commerce.Application.Features.Categories.Commands.UpdateCategory
{
    public record UpdateCategoryCommand : IRequest<CategoryDto>
    {
        public string? guid { get; init; }
        public string? Name { get; init; }
        public IFormFile? Image { get; init; }

        public string? ParentId { get; set; }

    }
}
