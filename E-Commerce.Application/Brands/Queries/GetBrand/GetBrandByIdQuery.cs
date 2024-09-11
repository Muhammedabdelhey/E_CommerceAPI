namespace E_Commerce.Application.Brands.Queries
{
    public record GetBrandByIdQuery(string Id):IRequest<Brand>;
}
