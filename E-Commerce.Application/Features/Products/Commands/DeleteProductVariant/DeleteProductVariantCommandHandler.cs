namespace E_Commerce.Application.Features.Products.Commands.DeleteProductVariant
{
    internal class DeleteProductVariantCommandHandler : IRequestHandler<DeleteProductVariantCommand, ProductVariantDto>
    {
        private readonly IBaseRepository<ProductVariant> _productVariantRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public DeleteProductVariantCommandHandler(IBaseRepository<ProductVariant> productVariantRepository, IMapper mapper, IFileService fileService)
        {
            _productVariantRepository = productVariantRepository;
            _mapper = mapper;
            _fileService = fileService;
        }
        public async Task<ProductVariantDto> Handle(DeleteProductVariantCommand request, CancellationToken cancellationToken)
        {
            var productVariants = await _productVariantRepository
                .GetByAsync(pv => pv.Id == Guid.Parse(request.productVariantId)
                && pv.ProductId == Guid.Parse(request.productId),
                cancellationToken);

            var productVariant = productVariants.FirstOrDefault()
                ?? throw new NotFoundException("Product Variant", request.productVariantId);

            await _productVariantRepository.DeleteAsync(productVariant, cancellationToken);
            if (productVariant.Image != null)
            {
                await _fileService.DeleteFileAsync(Constants.Products, productVariant.Image, cancellationToken);
            }
            return _mapper.Map<ProductVariantDto>(productVariant);
        }
    }
}
