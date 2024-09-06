namespace E_Commerce.Application.Brands.Commands.CreateBrand
{
    public record CreateBrandCommand : IRequest<Brand> 
    {
        public string Name { get; init; } 
        public string? Image { get; init; }
    }
}
