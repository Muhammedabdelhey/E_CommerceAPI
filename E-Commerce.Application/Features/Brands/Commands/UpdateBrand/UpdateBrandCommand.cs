namespace E_Commerce.Application.Features.Brands.Commands.UpdateBrand
{
    public record UpdateBrandCommand : IRequest<Brand>
    {
        public string Id { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public string? Image { get; init; }
    }
}
