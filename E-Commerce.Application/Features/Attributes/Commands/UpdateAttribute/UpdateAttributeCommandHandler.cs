namespace E_Commerce.Application.Features.Attributes.Commands.UpdateAttribute
{
    public class UpdateAttributeCommandHandler : IRequestHandler<UpdateAttributeCommand, AttributeDto>
    {
        private readonly IBaseRepository<Attribute> _attributeRepository;
        private readonly IMapper _mapper;
        public UpdateAttributeCommandHandler(IBaseRepository<Attribute> attributeRepository, IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;
        }

        public async Task<AttributeDto> Handle(UpdateAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = await _attributeRepository.GetByIdAsync(Guid.Parse(request.Guid), cancellationToken)
                ?? throw new NotFoundException($"Attribute with ID {request.Guid} not found.");
            attribute.Name = request.Name;
            await _attributeRepository.UpdateAsync(attribute, cancellationToken);
            return _mapper.Map<AttributeDto>(attribute);
        }
    }
}
