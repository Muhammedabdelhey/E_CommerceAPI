﻿using E_Commerce.Domain.Entities;

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
            var brand = await _brandRepository.GetByIdAsync(Guid.Parse(request.guid), cancellationToken)
                ?? throw new NotFoundException($"Brand with ID {request.guid} not found.");

            var image = brand.Image;
            brand.Name = request.Name;
            brand.Image = await _fileService.UploadFileAsync(Constants.Brands, request.Image, cancellationToken);
            await _brandRepository.UpdateAsync(brand, cancellationToken);

            if (image != null)
            {
                await _fileService.DeleteFileAsync(Constants.Brands, brand.Image, cancellationToken);
            }

            return _mapper.Map<BrandDto>(brand);
        }
    }
}
