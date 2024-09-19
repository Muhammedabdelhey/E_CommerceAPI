namespace E_Commerce.Application.Features.Brands.Queries.GetBrand
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, BrandDto>
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;
        public GetBrandByIdQueryHandler(IBaseRepository<Brand> brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<BrandDto> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken)
                ?? throw new NotFoundException($"Brand with ID {request.Id} not found.");
            return _mapper.Map<BrandDto>(brand);
        }
    }
}
