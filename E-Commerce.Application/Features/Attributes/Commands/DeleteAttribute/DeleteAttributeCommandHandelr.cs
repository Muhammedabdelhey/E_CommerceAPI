namespace E_Commerce.Application.Features.Attributes.Commands.DeleteAttribute
{
    public class DeleteAttributeCommandHandler : IRequestHandler<DeleteAttributeCommand,Unit>
    {
        private readonly IBaseRepository<Attribute> _attributeRepository;

        public DeleteAttributeCommandHandler(IBaseRepository<Attribute> attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }

        public async Task<Unit> Handle(DeleteAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = await _attributeRepository.GetByIdAsync(Guid.Parse(request.Guid), cancellationToken)
                ?? throw new NotFoundException("Attribute", request.Guid);
            await _attributeRepository.DeleteAsync(attribute, cancellationToken);

            return Unit.Value;
        }
    }
}
