namespace E_Commerce.Application.Features.Products.Queries.GetAllProducts
{
    public record GetProductsQuery : IRequest<IEnumerable<ProductDto>>;
}
