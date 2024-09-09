namespace E_Commerce.Application.Brands.Commands.DeleteBrand
{
    public record DeleteBrandCommand(string Id) : IRequest<Brand>;

}
