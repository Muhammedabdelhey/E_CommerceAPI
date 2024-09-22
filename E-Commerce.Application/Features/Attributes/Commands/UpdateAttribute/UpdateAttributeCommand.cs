namespace E_Commerce.Application.Features.Attributes.Commands.UpdateAttribute
{
    public record UpdateAttributeCommand : IRequest<AttributeDto>
    {
        public Guid Guid { get; init; }
        public string Name { get; init; } = string.Empty;

    }
}
