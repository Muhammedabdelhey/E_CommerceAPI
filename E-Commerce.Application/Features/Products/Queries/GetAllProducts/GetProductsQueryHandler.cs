
namespace E_Commerce.Application.Features.Products.Queries.GetAllProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IMapper _Mapper;
        public GetProductsQueryHandler(IBaseRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _Mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync([
                "Category",
                "Brand"], cancellationToken);
            return _Mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}
