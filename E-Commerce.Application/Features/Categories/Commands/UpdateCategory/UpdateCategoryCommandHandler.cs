﻿using System.Reflection;

namespace E_Commerce.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(IBaseRepository<Category> categoryRepository, IFileService fileService, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(Guid.Parse(request.Guid), ["Parent"], cancellationToken)
                ?? throw new NotFoundException("Category", request.Guid);

            var image = category.Image;

            category.Name = request.Name;
            category.Image = await _fileService.UploadFileAsync(request.Image, cancellationToken);
            category.ParentId = request.ParentId != null ? Guid.Parse(request.ParentId) : null;
            category = await _categoryRepository.UpdateAsync(category, cancellationToken);

            if (image != null)
            {
                await _fileService.DeleteFileAsync(image, cancellationToken);
            }
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
