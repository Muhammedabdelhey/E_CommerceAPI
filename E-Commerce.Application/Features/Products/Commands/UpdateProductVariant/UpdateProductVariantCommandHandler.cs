using E_Commerce.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace E_Commerce.Application.Features.Products.Commands.UpdateProductVariant
{
    public class UpdateProductVariantCommandHandler : IRequestHandler<UpdateProductVariantCommand, ProductVariantDto>
    {
        private readonly IBaseRepository<ProductVariant> _productVariantRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IBaseRepository<Product> _productRepository;

        public UpdateProductVariantCommandHandler(IBaseRepository<ProductVariant> productVariantRepository, IMapper mapper, IFileService fileService, IBaseRepository<Product> productRepository)
        {
            _productVariantRepository = productVariantRepository;
            _mapper = mapper;
            _fileService = fileService;
            _productRepository = productRepository;
        }

        public async Task<ProductVariantDto> Handle(UpdateProductVariantCommand request, CancellationToken cancellationToken)
        {
            var productVariant = await _productVariantRepository.GetByIdAsync(Guid.Parse(request.Guid),
                ["ProductVariantAttributes", "Product"], cancellationToken)
                ?? throw new NotFoundException("Product Variant", request.Guid);

            var image = productVariant.Image;
            productVariant.Stock = request.Stock;
            productVariant.Price = request.Price;
            productVariant.ProductId = Guid.Parse(request.ProductId);
            productVariant.Image = await _fileService.UploadFileAsync(Constants.Products, request.Image, cancellationToken);
            productVariant.Sku = await GenerateSku(productVariant, cancellationToken);

            productVariant.ProductVariantAttributes = request.Attributes.Select(attribute =>
                new ProductVariantAttributes
                {
                    AttributeId = Guid.Parse(attribute.Guid),
                    Value = attribute.Value
                }
            ).ToList();

            productVariant = await _productVariantRepository.UpdateAsync(productVariant, cancellationToken);
            if (image != null)
            {
                await _fileService.DeleteFileAsync(Constants.Products, image, cancellationToken);
            }
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
