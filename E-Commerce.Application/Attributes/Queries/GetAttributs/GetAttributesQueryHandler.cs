namespace E_Commerce.Application.Attributes.Queries.GetAttributs
{
    public class GetAttributesQueryHandler : IRequestHandler<GetAttributesQuery, IEnumerable<Attribute>>
    {
        private readonly IBaseRepository<Attribute> _attributeRepository;

        public GetAttributesQueryHandler(IBaseRepository<Attribute> attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }

        public async Task<IEnumerable<Attribute>> Handle(GetAttributesQuery request, CancellationToken cancellationToken)
        {
            var attributes = await _attributeRepository.GetAllAsync(cancellationToken);
            return attributes;
        }
    }
}
