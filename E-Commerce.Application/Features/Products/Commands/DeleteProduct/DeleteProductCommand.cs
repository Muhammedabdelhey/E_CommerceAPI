namespace E_Commerce.Application.Features.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(string Guid) : IRequest<Unit>;
}
