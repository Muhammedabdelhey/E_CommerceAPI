namespace E_Commerce.Application.Features.Brands
{
    public class BrandDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }
    }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Brand, BrandDto>();
        }
    }
}
