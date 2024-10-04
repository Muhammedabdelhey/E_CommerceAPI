using E_Commerce.Application.Features.Attributes;

namespace E_Commerce.Application.Features.Categories
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }
        public Guid? ParentId { get; set; }
        public string? ParentName { get; set; }
        public IReadOnlyCollection<AttributeDto> Attributes { get; set; } = [];
        private class CategoryMapping : Profile
        {
            public CategoryMapping()
            {
                CreateMap<Category, CategoryDto>()
                    .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent.Name))
                    .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => src.Attributes));

            }
        }
    }

}
