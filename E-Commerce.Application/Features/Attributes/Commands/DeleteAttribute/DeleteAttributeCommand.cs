namespace E_Commerce.Application.Features.Attributes.Commands.DeleteAttribute
{
    public record DeleteAttributeCommand(string guid) : IRequest<Attribute>;

}
