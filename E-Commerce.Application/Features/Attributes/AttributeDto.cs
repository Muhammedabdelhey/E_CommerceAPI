namespace E_Commerce.Application.Features.Attributes
{
    public class AttributeDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }

    public class AttributeMapping : Profile
    {
        public AttributeMapping()
        {
            CreateMap<Attribute, AttributeDto>();
        }
    }
}

