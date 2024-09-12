namespace E_Commerce.Application.Attributes.Queries.GetAttributeById
{
    public record GetAttributeByIdQuery(string guid) : IRequest<Attribute>;
}
