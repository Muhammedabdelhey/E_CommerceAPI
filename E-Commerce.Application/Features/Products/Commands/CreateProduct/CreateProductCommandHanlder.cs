namespace E_Commerce.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHanlder : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public CreateProductCommandHanlder(IBaseRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new()
            {
                Name = request.Name,
                Description = request.Description,
                CategoryId = Guid.Parse(request.CategoryId),
                BrandId = Guid.Parse(request.BrandId)
            };
            await _productRepository.AddAsync(product, cancellationToken);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
