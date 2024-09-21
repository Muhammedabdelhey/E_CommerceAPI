namespace E_Commerce.Application.Features.Attributes.Queries.GetAttributs
{
    public class GetAttributesQueryHandler : IRequestHandler<GetAttributesQuery, IEnumerable<AttributeDto>>
    {
        private readonly IBaseRepository<Attribute> _attributeRepository;
        private readonly IMapper _mapper;
        public GetAttributesQueryHandler(IBaseRepository<Attribute> attributeRepository, IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AttributeDto>> Handle(GetAttributesQuery request, CancellationToken cancellationToken)
        {
            var attributes = await _attributeRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<AttributeDto>>(attributes);
        }
    }
}
