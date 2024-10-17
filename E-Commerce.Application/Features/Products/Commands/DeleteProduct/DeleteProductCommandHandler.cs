
namespace E_Commerce.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IBaseRepository<Product> _productRepository;
        public DeleteProductCommandHandler(IBaseRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(Guid.Parse(request.Guid), cancellationToken)
                ?? throw new NotFoundException("Product", request.Guid);
            await _productRepository.DeleteAsync(product, cancellationToken);
            return Unit.Value;
        }
    }
}
