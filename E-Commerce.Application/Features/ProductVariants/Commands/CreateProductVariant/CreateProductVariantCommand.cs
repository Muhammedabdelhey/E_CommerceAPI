namespace E_Commerce.Application.Features.ProductVariants.Commands.CreateProductVariant
{
    public record CreateProductVariantCommand : IRequest<ProductVariantDto>
    {
        public string ProductId { get; init; } = string.Empty;
        public int Stock { get; init; }
        public double Price { get; init; }
        public IFormFile? Image { get; init; }
        public List<AttributeObj> Attributes { get; init; } = [];
    }
}
