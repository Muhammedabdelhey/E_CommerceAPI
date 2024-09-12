namespace E_Commerce.Application.Attributes.Queries.GetAttributeById
{
    public class GetAttributeByIdHandler : IRequestHandler<GetAttributeByIdQuery, Attribute>
    {
        private readonly IBaseRepository<Attribute> _attributeRepository;

        public GetAttributeByIdHandler(IBaseRepository<Attribute> attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }

        public async Task<Attribute> Handle(GetAttributeByIdQuery request, CancellationToken cancellationToken)
        {
            var attribute = await _attributeRepository.GetByIdAsync(Guid.Parse(request.guid), cancellationToken);
            if (attribute == null)
            {
                throw new NotFoundException($"Attribute with guid{request.guid} not found");
            }
            return attribute;
        }
    }
}
