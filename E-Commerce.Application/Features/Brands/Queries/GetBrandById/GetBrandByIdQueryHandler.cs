namespace E_Commerce.Application.Features.Brands.Queries.GetBrand
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, BrandDto>
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public GetBrandByIdQueryHandler(IBaseRepository<Brand> brandRepository, IMapper mapper, IFileService fileService)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _fileService = fileService;
        }
        public async Task<BrandDto> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(Guid.Parse(request.guid), cancellationToken)
                ?? throw new NotFoundException("Brand", request.guid);
            return _mapper.Map<BrandDto>(brand);
        }
    }
}
