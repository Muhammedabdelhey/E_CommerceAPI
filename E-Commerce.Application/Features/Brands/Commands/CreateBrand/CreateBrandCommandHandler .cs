namespace E_Commerce.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Brand>
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        private readonly IFileService _fileService;
        public CreateBrandCommandHandler(IBaseRepository<Brand> brandRepository, IFileService fileService)
        {
            _brandRepository = brandRepository;
            _fileService = fileService;
        }
        public async Task<Brand> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            string? image = null;
            if (request.Image != null)
            {
                image = await _fileService.UploadFileAsync(Constants.Brands, request.Image);
            }
            Brand brand = new()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Image = image
            };
            await _brandRepository.AddAsync(brand, cancellationToken);
            return brand;
        }
    }
}
