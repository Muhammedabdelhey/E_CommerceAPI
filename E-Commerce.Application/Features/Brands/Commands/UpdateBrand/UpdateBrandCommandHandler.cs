using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Brand>
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        private readonly IFileService _fileService;
        public UpdateBrandCommandHandler(IBaseRepository<Brand> brandRepository, IFileService fileService)
        {
            _brandRepository = brandRepository;
            _fileService = fileService;
        }

        public async Task<Brand> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken);
            if (brand == null)
            {
                throw new NotFoundException($"Brand with ID {request.Id} not found.");
            }
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
            return brand;
        }
    }
}
