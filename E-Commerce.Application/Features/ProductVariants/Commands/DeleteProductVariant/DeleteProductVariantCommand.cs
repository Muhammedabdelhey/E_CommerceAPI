namespace E_Commerce.Application.Features.ProductVariants.Commands.DeleteProductVariant
{
    public record DeleteProductVariantCommand(string productId, string productVariantId) : IRequest<ProductVariantDto>;
}
