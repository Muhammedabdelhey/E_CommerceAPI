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
        private class CategoryMapping : Profile
        {
            public CategoryMapping()
            {
                CreateMap<Category, CategoryDto>()
                    .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent.Name));
            }
        }
    }

}
