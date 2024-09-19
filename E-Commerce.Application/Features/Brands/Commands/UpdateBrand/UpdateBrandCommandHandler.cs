using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, BrandDto>
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public UpdateBrandCommandHandler(IBaseRepository<Brand> brandRepository, IFileService fileService, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<BrandDto> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken)
                ?? throw new NotFoundException($"Brand with ID {request.Id} not found.");

            var image = brand.Image;
            if (image != null)
            {
                await _fileService.DeleteFileAsync(Constants.Brands, image);
                image = null;
            }
            if (request.Image != null)
            {
                image = await _fileService.UploadFileAsync(Constants.Brands, request.Image);
            }
            brand.Name = request.Name;
            brand.Image = image;
            await _brandRepository.UpdateAsync(brand, cancellationToken);
            return _mapper.Map<BrandDto>(brand);
        }
    }
}
