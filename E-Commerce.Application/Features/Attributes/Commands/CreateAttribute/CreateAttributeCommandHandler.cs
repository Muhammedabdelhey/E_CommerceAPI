namespace E_Commerce.Application.Features.Attributes.Commands.CreateAttribute
{
    public class CreateAttributeCommandHandler : IRequestHandler<CreateAttributeCommand, Attribute>
    {
        IBaseRepository<Attribute> _atrributeRepository;
        public CreateAttributeCommandHandler(IBaseRepository<Attribute> atrributeRepository)
        {
            _atrributeRepository = atrributeRepository;
        }
        public async Task<Attribute> Handle(CreateAttributeCommand request, CancellationToken cancellationToken)
        {
            Attribute attribute = new()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
            };
            await _atrributeRepository.AddAsync(attribute, cancellationToken);
            return attribute;
        }
    }
}
