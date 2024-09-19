namespace E_Commerce.Application.Features.Brands.Queries.GetBrands
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, IEnumerable<BrandDto>>
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;
        public GetBrandsQueryHandler(IBaseRepository<Brand> brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BrandDto>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _brandRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<BrandDto>>(brands);
        }
    }
}
