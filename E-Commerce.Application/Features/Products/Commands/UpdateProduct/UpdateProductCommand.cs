﻿namespace E_Commerce.Application.Features.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand: IRequest<ProductDto>
    {
        public Guid guid { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public Guid CategoryId { get; init; }
        public Guid BrandId { get; init; }
    }
}