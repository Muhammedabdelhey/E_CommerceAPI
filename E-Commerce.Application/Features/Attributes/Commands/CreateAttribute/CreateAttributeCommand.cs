namespace E_Commerce.Application.Features.Attributes.Commands.CreateAttribute
{
    public record CreateAttributeCommand : IRequest<AttributeDto>
    {
        public string Name { get; init; } = string.Empty;
    }
}
