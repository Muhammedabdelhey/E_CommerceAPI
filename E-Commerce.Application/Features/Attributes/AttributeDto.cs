namespace E_Commerce.Application.Features.Attributes
{
    public class AttributeDto
    {
        public Guid Id { get; set; }
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

