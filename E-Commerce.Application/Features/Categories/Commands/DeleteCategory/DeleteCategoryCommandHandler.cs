
namespace E_Commerce.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IFileService _fileService;
        public DeleteCategoryCommandHandler(IBaseRepository<Category> categoryRepository, IFileService fileService)
        {
            _categoryRepository = categoryRepository;
            _fileService = fileService;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(Guid.Parse(request.Guid), cancellationToken)
                ?? throw new NotFoundException("Category", request.Guid);

            await _categoryRepository.DeleteAsync(category, cancellationToken);

            if (category.Image != null)
            {
                await _fileService.DeleteFileAsync(category.Image,cancellationToken);
            }

            return Unit.Value;
        }
    }
}
