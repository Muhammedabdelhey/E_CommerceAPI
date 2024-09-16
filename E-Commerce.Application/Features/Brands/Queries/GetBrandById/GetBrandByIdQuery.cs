namespace E_Commerce.Application.Features.Brands.Queries
{
    public record GetBrandByIdQuery(string Id):IRequest<Brand>;
}
