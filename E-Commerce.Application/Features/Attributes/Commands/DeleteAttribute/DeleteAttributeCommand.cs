namespace E_Commerce.Application.Features.Attributes.Commands.DeleteAttribute
{
    public record DeleteAttributeCommand(Guid guid) : IRequest<AttributeDto>;

}
