namespace E_Commerce.Application.Features.Brands.Commands.DeleteBrand
{
    public record DeleteBrandCommand(string Id) : IRequest<BrandDto>;

}
