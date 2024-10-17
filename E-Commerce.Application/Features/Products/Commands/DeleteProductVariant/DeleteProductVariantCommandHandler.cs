namespace E_Commerce.Application.Features.Products.Commands.DeleteProductVariant
{
    internal class DeleteProductVariantCommandHandler : IRequestHandler<DeleteProductVariantCommand, Unit>
    {
        private readonly IBaseRepository<ProductVariant> _productVariantRepository;
        private readonly IFileService _fileService;
        public DeleteProductVariantCommandHandler(IBaseRepository<ProductVariant> productVariantRepository, IFileService fileService)
        {
            _productVariantRepository = productVariantRepository;
            _fileService = fileService;
        }
        public async Task<Unit> Handle(DeleteProductVariantCommand request, CancellationToken cancellationToken)
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
            return Unit.Value;
        }
    }
}
