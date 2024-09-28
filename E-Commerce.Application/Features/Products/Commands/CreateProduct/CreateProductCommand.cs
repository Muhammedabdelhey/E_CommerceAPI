namespace E_Commerce.Application.Features.Products.Commands.CreateProduct
{
    public record CreateProductCommand : IRequest<ProductDto>
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public string CategoryId { get; init; } = string.Empty;
        public string BrandId { get; init; } = string.Empty;
    }
}
