namespace E_Commerce.Application.Features.Brands.Commands.UpdateBrand
{
    public record UpdateBrandCommand : IRequest<BrandDto>
    {
        public string guid { get; init; } = string.Empty; 
        public string Name { get; init; } = string.Empty;
        public IFormFile? Image { get; init; }
    }
}
