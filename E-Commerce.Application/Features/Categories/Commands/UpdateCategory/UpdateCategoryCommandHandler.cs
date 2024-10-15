using System.Reflection;

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
            var category = await _categoryRepository.GetByIdAsync(Guid.Parse(request.guid), ["Parent"], cancellationToken)
                ?? throw new NotFoundException($"Category with Guid {request.guid} not found");

            var image = category.Image;

            category.Name = request.Name;
            category.Image = await _fileService.UploadFileAsync(Constants.Category, request.Image, cancellationToken);
            category.ParentId = request.ParentId != null ? Guid.Parse(request.ParentId):null;
            category = await _categoryRepository.UpdateAsync(category, cancellationToken);

            if (image != null)
            {
                await _fileService.DeleteFileAsync(Constants.Category, image,cancellationToken);
            }
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
