namespace E_Commerce.Application.Features.Attributes.Commands.DeleteAttribute
{
    public record DeleteAttributeCommand(string Guid) : IRequest<Unit>;

}
