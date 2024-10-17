namespace E_Commerce.Application.Features.Attributes.Commands.DeleteAttribute
{
    public class DeleteAttributeCommandHandelr : IRequestHandler<DeleteAttributeCommand, AttributeDto>
    {
        private readonly IBaseRepository<Attribute> _attributeRepsoitory;
        private readonly IMapper _mapper;
        public DeleteAttributeCommandHandelr(IBaseRepository<Attribute> attributeRepsoitory, IMapper mapper)
        {
            _attributeRepsoitory = attributeRepsoitory;
            _mapper = mapper;
        }

        public async Task<AttributeDto> Handle(DeleteAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = await _attributeRepsoitory.GetByIdAsync(Guid.Parse(request.guid), cancellationToken)
                ?? throw new NotFoundException("Attribute", request.guid);
            await _attributeRepsoitory.DeleteAsync(attribute, cancellationToken);
            return _mapper.Map<AttributeDto>(attribute);
        }
    }
}
