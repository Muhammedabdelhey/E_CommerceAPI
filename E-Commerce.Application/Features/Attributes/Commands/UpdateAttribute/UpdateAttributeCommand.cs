namespace E_Commerce.Application.Features.Attributes.Commands.UpdateAttribute
{
    public record UpdateAttributeCommand : IRequest<Attribute>
    {
        public string Guid { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;

    }
}
