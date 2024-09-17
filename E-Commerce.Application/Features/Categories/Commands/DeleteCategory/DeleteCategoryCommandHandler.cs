
namespace E_Commerce.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Category>
    {
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IFileService _fileService;
        public DeleteCategoryCommandHandler(IBaseRepository<Category> categoryRepository, IFileService fileService)
        {
            _categoryRepository = categoryRepository;
            _fileService = fileService;
        }

        public async Task<Category> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
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
            }
            await _categoryRepository.DeleteAsync(category, cancellationToken);
            return category;
        }
    }
}
