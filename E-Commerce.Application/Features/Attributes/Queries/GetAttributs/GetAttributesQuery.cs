namespace E_Commerce.Application.Features.Attributes.Queries.GetAttributs
{
    public record GetAttributesQuery : IRequest<IEnumerable<AttributeDto>>;
}
