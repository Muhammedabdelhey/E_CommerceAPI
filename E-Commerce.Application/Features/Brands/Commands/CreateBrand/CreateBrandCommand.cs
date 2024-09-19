namespace E_Commerce.Application.Features.Brands.Commands.CreateBrand
{
    public record CreateBrandCommand : IRequest<BrandDto> 
    {
        public string? Name { get; init; } 
        public IFormFile? Image { get; init; }
    }
}
