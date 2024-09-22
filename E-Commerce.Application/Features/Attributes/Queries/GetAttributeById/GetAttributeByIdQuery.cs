namespace E_Commerce.Application.Features.Attributes.Queries.GetAttributeById
{
    public record GetAttributeByIdQuery(Guid guid) : IRequest<AttributeDto>;
}
