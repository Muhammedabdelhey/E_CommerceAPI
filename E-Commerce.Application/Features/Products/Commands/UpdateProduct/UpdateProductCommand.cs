namespace E_Commerce.Application.Features.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand : IRequest<ProductDto>
    {
        public string Guid { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public string CategoryId { get; init; } = string.Empty;
        public string BrandId { get; init; } = string.Empty;
    }
}
