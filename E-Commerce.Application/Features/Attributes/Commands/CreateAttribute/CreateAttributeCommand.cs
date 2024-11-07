namespace E_Commerce.Application.Features.Attributes.Commands.CreateAttribute
{
    public record CreateAttributeCommand(string Name) : IRequest<AttributeDto>;
}
