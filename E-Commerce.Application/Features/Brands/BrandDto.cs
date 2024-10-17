using E_Commerce.Application.Common.Resolvers;
using E_Commerce.Application.Features.Products;

namespace E_Commerce.Application.Features.Brands
{
    public class BrandDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }
    }

    public class BrandMapping : Profile
    {
        public BrandMapping()
        {
            CreateMap<Brand, BrandDto>()
                .ForMember(dest => dest.Image, opt =>
                    opt.MapFrom<ImageResolver<Brand, BrandDto>>());
        }
    }
}
