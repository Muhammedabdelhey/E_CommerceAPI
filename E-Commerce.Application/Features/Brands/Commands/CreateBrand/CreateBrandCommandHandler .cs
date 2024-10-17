using E_Commerce.Application.Features.Categories;

namespace E_Commerce.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, BrandDto>
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public CreateBrandCommandHandler(IBaseRepository<Brand> brandRepository, IFileService fileService, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _fileService = fileService;
            _mapper = mapper;
        }
        public async Task<BrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand brand = new()
            {
                Name = request.Name,
                Image = await _fileService.UploadFileAsync(request.Image, cancellationToken)
            };
            brand = await _brandRepository.AddAsync(brand, cancellationToken);
            return _mapper.Map<BrandDto>(brand);
        }
    }
}
