using E_Commerce.Application.Interfaces;

namespace E_Commerce.Application.Features.Brands
{
    public class BrandDto
    {
        public BrandDto()
        {
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }
    }

    public class BrandMapping : Profile
    {
        public BrandMapping()
        {

            CreateMap<Brand, BrandDto>();
        }
    }
}
