namespace E_Commerce.Application.Features.Products.Commands.DeleteProductVariant
{
    public record DeleteProductVariantCommand(string productId, string productVariantId) : IRequest<Unit>;
}
