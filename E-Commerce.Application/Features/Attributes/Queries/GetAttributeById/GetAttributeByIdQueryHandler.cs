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
            var attribute = await _attributeRepository.GetByIdAsync(Guid.Parse(request.Guid), cancellationToken)
                ?? throw new NotFoundException("Attribute", request.Guid);
            return _mapper.Map<AttributeDto>(attribute);

        }
    }
}
