namespace E_Commerce.Application.Features.Products
{
    public class ProductVariantDto
    {
        public string Id { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public int Stock { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
        public string ProductId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public List<AttributeValues> Attributes { get; set; } = new List<AttributeValues>();
        public class AttributeValues
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Value { get; set; } = string.Empty;
        }
        private class ProductVariantMapping : Profile
        {
            public ProductVariantMapping()
            {
                CreateMap<ProductVariant, ProductVariantDto>()
                    .ForMember(dest => dest.ProductName,
                        opt => opt.MapFrom(src => src.Product.Name))

                    .ForMember(dest => dest.Attributes,
                        opt => opt.MapFrom(src => src.ProductVariantAttributes
                            .Select(pva => new AttributeValues
                            {
                                Id = pva.AttributeId,
                                Name = pva.Attribute.Name,
                                Value = pva.Value
                            })
                        ));
            }
        }
    }
}
