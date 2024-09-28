namespace E_Commerce.Application.Features.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(string guid) : IRequest<ProductDto>;
}
