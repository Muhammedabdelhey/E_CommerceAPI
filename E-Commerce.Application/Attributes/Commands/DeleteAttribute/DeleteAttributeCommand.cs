namespace E_Commerce.Application.Attributes.Commands.DeleteAttribute
{
    public record DeleteAttributeCommand(string guid) : IRequest<Attribute>;

}
