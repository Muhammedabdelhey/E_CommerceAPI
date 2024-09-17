namespace E_Commerce.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Category>
    {
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IFileService _fileService;
        public UpdateCategoryCommandHandler(IBaseRepository<Category> categoryRepository, IFileService fileService)
        {
            _categoryRepository = categoryRepository;
            _fileService = fileService;
        }

        public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(Guid.Parse(request.guid), cancellationToken);
            if (category == null)
            {
                throw new NotFoundException($"Category with Guid {request.guid} not found");
            }
            var image = category.Image;
            if (image != null)
            {
                await _fileService.DeleteFileAsync(Constants.Category, image);
                image = null;
            }
            if (request.Image != null)
            {
                image = await _fileService.UploadFileAsync(Constants.Category, request.Image);
            }
            Guid? parentId = null;
            if (!string.IsNullOrEmpty(request.ParentId))
            {
                parentId = Guid.Parse(request.ParentId);
            }
            category.Name = request.Name;
            category.Image = image;
            category.ParentId = parentId;
            category = await _categoryRepository.UpdateAsync(category, cancellationToken);
            return category;
        }
    }
}
