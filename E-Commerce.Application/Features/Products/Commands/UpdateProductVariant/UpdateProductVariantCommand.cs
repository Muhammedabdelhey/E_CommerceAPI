namespace E_Commerce.Application.Features.Products.Commands.UpdateProductVariant
{
    public class UpdateProductVariantCommand : IRequest<ProductVariantDto>
    {
        public string Guid { get; init; } = string.Empty;
        public string ProductId { get; init; } = string.Empty;
        public int Stock { get; init; }
        public double Price { get; init; }
        public IFormFile? Image { get; init; }
        public List<AttributeObj> Attributes { get; init; } = [];
    }
}
