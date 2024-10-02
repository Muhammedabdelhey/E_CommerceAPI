namespace E_Commerce.Application.Features.Products.Queries.GetProductVariants
{
    public class GetProductVariantsQueryHandler : IRequestHandler<GetProductVariantsQuery, IEnumerable<ProductVariantDto>>
    {
        private readonly IBaseRepository<ProductVariant> _productVariantRepository;
        private readonly IMapper _mapper;
        public GetProductVariantsQueryHandler(IBaseRepository<ProductVariant> productVariantRepository, IMapper mapper)
        {
            _productVariantRepository = productVariantRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVariantDto>> Handle(GetProductVariantsQuery request, CancellationToken cancellationToken)
        {
            var productVariants = await _productVariantRepository
                .GetByAsync(pv => pv.ProductId == Guid.Parse(request.productId),
                ["Product", "ProductVariantAttributes.Attribute"],
                cancellationToken);
            return _mapper.Map<IEnumerable<ProductVariantDto>>(productVariants);
        }
    }
}
