namespace E_Commerce.Application.Features.Products
{
    public class ProductDto
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public Guid CategoryId { get; init; }
        public Guid BrandId { get; init; }

        private class ProductMapping : Profile
        {
            public ProductMapping()
            {
                CreateMap<Product, ProductDto>();
            }
        }
    }
}
