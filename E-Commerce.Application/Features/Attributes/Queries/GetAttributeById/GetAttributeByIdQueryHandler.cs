namespace E_Commerce.Application.Features.Attributes.Queries.GetAttributeById
{
    public class GetAttributeByIdQueryHandler : IRequestHandler<GetAttributeByIdQuery, AttributeDto>
    {
        private readonly IBaseRepository<Attribute> _attributeRepository;
        private readonly IMapper _mapper;
        public GetAttributeByIdQueryHandler(IBaseRepository<Attribute> attributeRepository, IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;
        }

        public async Task<AttributeDto> Handle(GetAttributeByIdQuery request, CancellationToken cancellationToken)
        {
            var attribute = await _attributeRepository.GetByIdAsync(request.guid, cancellationToken)
                ?? throw new NotFoundException($"Attribute with guid {request.guid} not found");
            return _mapper.Map<AttributeDto>(attribute);

        }
    }
}
