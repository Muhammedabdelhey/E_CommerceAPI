
namespace E_Commerce.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IBaseRepository<Product> repository, IMapper mapper)
        {
            _productRepository = repository;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(Guid.Parse(request.guid), ["Category", "Brand"], cancellationToken)
                ?? throw new NotFoundException("Product", request.guid);
            product.Name = request.Name;
            product.Description = request.Description;
            product.CategoryId = Guid.Parse(request.CategoryId);
            product.BrandId = Guid.Parse(request.BrandId);
            product = await _productRepository.UpdateAsync(product, cancellationToken);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
