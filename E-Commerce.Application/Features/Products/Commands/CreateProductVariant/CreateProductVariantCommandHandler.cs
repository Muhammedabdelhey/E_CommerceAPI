namespace E_Commerce.Application.Features.Products.Commands.CreateProductVariant
{
    public class CreateProductVariantCommandHandler : IRequestHandler<CreateProductVariantCommand, ProductVariantDto>
    {
        private readonly IBaseRepository<ProductVariant> _productVariantRepository;
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public CreateProductVariantCommandHandler(IBaseRepository<ProductVariant> productVariantRepository, IMapper mapper, IFileService fileService, IBaseRepository<Product> productRepository)
        {
            _productVariantRepository = productVariantRepository;
            _mapper = mapper;
            _fileService = fileService;
            _productRepository = productRepository;
        }
        public async Task<ProductVariantDto> Handle(CreateProductVariantCommand request, CancellationToken cancellationToken)
        {
            ProductVariant productVariant = new()
            {
                Price = request.Price,
                Stock = request.Stock,
                ProductId = Guid.Parse(request.ProductId),
                Image = await _fileService.UploadFileAsync(request.Image, cancellationToken),
                ProductVariantAttributes = request.Attributes.Select(attribute =>
                    new ProductVariantAttributes
                    {
                        AttributeId = Guid.Parse(attribute.Guid),
                        Value = attribute.Value
                    }).ToList(),
            };
            productVariant.Sku = await GenerateSku(productVariant, cancellationToken);
            await _productVariantRepository.AddAsync(productVariant, cancellationToken);
            return _mapper.Map<ProductVariantDto>(productVariant);
        }
        private async Task<string> GenerateSku(ProductVariant productVariant, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(productVariant.ProductId, cancellationToken);
            var sku = $"{product.Name}";
            foreach (var attribute in productVariant.ProductVariantAttributes)
            {
                sku += $"-{attribute.Value}";
            }
            return sku.ToUpper();
        }
    }
}
