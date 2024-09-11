
namespace E_Commerce.Application.Attributes.Commands.UpdateAttribute
{
    public class UpdateAttributeCommandHandler : IRequestHandler<UpdateAttributeCommand, Attribute>
    {
        private readonly IBaseRepository<Attribute> _attributeRepository;

        public UpdateAttributeCommandHandler(IBaseRepository<Attribute> attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }

        public async Task<Attribute> Handle(UpdateAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = await _attributeRepository.GetByIdAsync(Guid.Parse(request.Guid), cancellationToken);
            if(attribute == null)
            {
                throw new NotFoundException($"Attribute with ID {request.Guid} not found.");
            }
            attribute.Name = request.Name;
            await _attributeRepository.UpdateAsync(attribute);
            return attribute;
        }
    }
}
