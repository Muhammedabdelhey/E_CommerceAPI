namespace E_Commerce.Application.Features.ProductVariants.Commands.UpdateProductVariant
{
    public class UpdateProductVariantCommand : IRequest<ProductVariantDto>
    {
        public string guid { get; init; } = string.Empty;
        public string ProductId { get; init; } = string.Empty;
        public int Stock { get; init; }
        public double Price { get; init; }
        public IFormFile? Image { get; init; }
        public List<AttributeObj> Attributes { get; init; } = [];
    }
}
