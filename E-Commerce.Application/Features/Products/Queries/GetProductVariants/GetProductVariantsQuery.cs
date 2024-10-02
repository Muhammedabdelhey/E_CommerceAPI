namespace E_Commerce.Application.Features.Products.Queries.GetProductVariants
{
    public record GetProductVariantsQuery(string productId) : IRequest<IEnumerable<ProductVariantDto>>;
}
