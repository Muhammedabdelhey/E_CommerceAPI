namespace E_Commerce.Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, BrandDto>
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public DeleteBrandCommandHandler(IBaseRepository<Brand> brandRepository, IFileService fileService, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<BrandDto> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(Guid.Parse(request.guid), cancellationToken)
                ?? throw new NotFoundException($"Brand with ID {request.guid} not found.");

            await _brandRepository.DeleteAsync(brand, cancellationToken);

            if (brand.Image != null)
            {
                await _fileService.DeleteFileAsync(Constants.Brands, brand.Image);
            }

            return _mapper.Map<BrandDto>(brand);
        }
    }
}
