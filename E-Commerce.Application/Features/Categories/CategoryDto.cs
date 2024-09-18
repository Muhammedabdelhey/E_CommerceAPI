﻿namespace E_Commerce.Application.Features.Categories
{
    public class CategoryDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string? Image { get; init; }
        public Guid? ParentId { get; init; }
        public string? ParentName { get; init; }
        public IReadOnlyCollection<CategoryDto> Childrens { get; init; } = Array.Empty<CategoryDto>();
        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Category, CategoryDto>()
                    .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent.Name))
                    .ForMember(dest => dest.Childrens, opt => opt.MapFrom(src => src.Childrens));
            }
        }
    }

}
