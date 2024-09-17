namespace E_Commerce.Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Brand>
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        private readonly IFileService _fileService;

        public DeleteBrandCommandHandler(IBaseRepository<Brand> brandRepository, IFileService fileService)
        {
            _brandRepository = brandRepository;
            _fileService = fileService;
        }

        public async Task<Brand> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
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
            }
            await _brandRepository.DeleteAsync(brand);
            return brand;
        }
    }
}
