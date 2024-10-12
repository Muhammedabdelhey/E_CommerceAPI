namespace E_Commerce.Application.Features.Attributes.Commands.CreateAttribute
{
    public class CreateAttributeCommandHandler : IRequestHandler<CreateAttributeCommand, AttributeDto>
    {
        private readonly IBaseRepository<Attribute> _atrributeRepository;
        private readonly IMapper _mapper;
        public CreateAttributeCommandHandler(IBaseRepository<Attribute> atrributeRepository, IMapper mapper)
        {
            _atrributeRepository = atrributeRepository;
            _mapper = mapper;
        }
        public async Task<AttributeDto> Handle(CreateAttributeCommand request, CancellationToken cancellationToken)
        {
            Attribute attribute = new()
            {
                Name = request.Name,
            };
            await _atrributeRepository.AddAsync(attribute, cancellationToken);
            return _mapper.Map<AttributeDto>(attribute);
        }
    }
}
