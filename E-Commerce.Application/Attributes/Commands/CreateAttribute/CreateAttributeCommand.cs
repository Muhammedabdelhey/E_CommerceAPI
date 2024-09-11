namespace E_Commerce.Application.Attributes.Commands.CreateAttribute
{
    public record CreateAttributeCommand : IRequest<Attribute>
    {
        public string Name { get; init; } = string.Empty;
    }
}
