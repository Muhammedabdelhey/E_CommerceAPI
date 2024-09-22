namespace E_Commerce.Application.Features.Brands.Commands.DeleteBrand
{
    public record DeleteBrandCommand(Guid guid) : IRequest<BrandDto>;

}
