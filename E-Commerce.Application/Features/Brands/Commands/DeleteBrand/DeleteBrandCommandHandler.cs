﻿namespace E_Commerce.Application.Features.Brands.Commands.DeleteBrand
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
            var brand = await _brandRepository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken)
                ?? throw new NotFoundException($"Brand with ID {request.Id} not found.");
            var image = brand.Image;
            if (image != null)
            {
                await _fileService.DeleteFileAsync(Constants.Brands, image);
            }
            await _brandRepository.DeleteAsync(brand, cancellationToken);
            return _mapper.Map<BrandDto>(brand);
        }
    }
}
