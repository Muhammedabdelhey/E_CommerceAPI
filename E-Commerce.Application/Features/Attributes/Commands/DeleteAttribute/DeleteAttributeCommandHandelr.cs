namespace E_Commerce.Application.Features.Attributes.Commands.DeleteAttribute
{
    public class DeleteAttributeCommandHandelr : IRequestHandler<DeleteAttributeCommand, Attribute>
    {
        private readonly IBaseRepository<Attribute> _attributeRepsoitory;

        public DeleteAttributeCommandHandelr(IBaseRepository<Attribute> attributeRepsoitory)
        {
            _attributeRepsoitory = attributeRepsoitory;
        }

        public async Task<Attribute> Handle(DeleteAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = await _attributeRepsoitory.GetByIdAsync(Guid.Parse(request.guid))
                ?? throw new NotFoundException($"Attribute with guid{request.guid} not found");
            await _attributeRepsoitory.DeleteAsync(attribute, cancellationToken);
            return attribute;
        }
    }
}
