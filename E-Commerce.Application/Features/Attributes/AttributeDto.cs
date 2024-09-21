namespace E_Commerce.Application.Features.Attributes
{
    public class AttributeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Attribute, AttributeDto>();
        }
    }
}

