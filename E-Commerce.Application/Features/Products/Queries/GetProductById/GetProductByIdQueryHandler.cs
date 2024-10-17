﻿
namespace E_Commerce.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IBaseRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(Guid.Parse(request.guid),["Category","Brand"], cancellationToken)
                ?? throw new NotFoundException($"Product", request.guid);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
