namespace E_Commerce.Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Unit>
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        private readonly IFileService _fileService;
        public DeleteBrandCommandHandler(IBaseRepository<Brand> brandRepository, IFileService fileService)
        {
            _brandRepository = brandRepository;
            _fileService = fileService;
        }

        public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(Guid.Parse(request.Guid), cancellationToken)
                ?? throw new NotFoundException("Brand", request.Guid);

            await _brandRepository.DeleteAsync(brand, cancellationToken);

            if (brand.Image != null)
            {
                await _fileService.DeleteFileAsync(brand.Image, cancellationToken);
            }

            return Unit.Value;
        }
    }
}
