namespace E_Commerce.Application.Features.Attributes.Commands.CreateAttribute
{
    public record CreateAttributeCommand : IRequest<Attribute>
    {
        public string Name { get; init; } = string.Empty;
    }
}
