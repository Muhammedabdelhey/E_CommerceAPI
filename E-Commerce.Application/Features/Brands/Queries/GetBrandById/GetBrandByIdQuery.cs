namespace E_Commerce.Application.Features.Brands.Queries
{
    public record GetBrandByIdQuery(Guid guid):IRequest<BrandDto>;
}
