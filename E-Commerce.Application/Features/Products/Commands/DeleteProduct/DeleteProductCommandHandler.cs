
namespace E_Commerce.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductDto>
    {
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public DeleteProductCommandHandler(IBaseRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(Guid.Parse(request.guid), cancellationToken)
                ?? throw new NotFoundException($"Product with Guid {request.guid} not Found");
            await _productRepository.DeleteAsync(product, cancellationToken);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
