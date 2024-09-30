using E_Commerce.Application.Features.ProductVariants;

namespace E_Commerce.Application.Features.Products
{
    public class ProductDto
    {
        public string Id { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public string CategoryId { get; init; } = string.Empty;
        public string CategoryName { get; init; } = string.Empty;
        public string BrandId { get; init; } = string.Empty;
        public string BrandName { get; init; } = string.Empty;
        public IReadOnlyCollection<ProductVariantDto> Variants { get; init; } = [];

        private class ProductMapping : Profile
        {
            public ProductMapping()
            {
                CreateMap<Product, ProductDto>()
                    .ForMember(dto => dto.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                    .ForMember(dto => dto.BrandName, opt => opt.MapFrom(src => src.Brand.Name));
            }
        }
    }
}
