
namespace E_Commerce.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CategoryDto>
    {
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public DeleteCategoryCommandHandler(IBaseRepository<Category> categoryRepository, IFileService fileService, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.guid, cancellationToken)
                ?? throw new NotFoundException($"Category with Guid {request.guid} not found");

            await _categoryRepository.DeleteAsync(category, cancellationToken);

            if (category.Image != null)
            {
                await _fileService.DeleteFileAsync(Constants.Category, category.Image);
            }

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
