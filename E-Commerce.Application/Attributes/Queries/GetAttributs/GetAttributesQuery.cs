namespace E_Commerce.Application.Attributes.Queries.GetAttributs
{
    public record GetAttributesQuery : IRequest<IEnumerable<Attribute>>;
}
