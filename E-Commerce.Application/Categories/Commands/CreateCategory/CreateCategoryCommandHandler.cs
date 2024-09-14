
using static System.Net.Mime.MediaTypeNames;

namespace E_Commerce.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
    {
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IFileService _fileService;
        public CreateCategoryCommandHandler(IBaseRepository<Category> categoryRepository, IFileService fileService)
        {
            _categoryRepository = categoryRepository;
            _fileService = fileService;
        }

        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            string? image = null;
            if (request.Image != null)
            {
                image = await _fileService.UploadFileAsync("Category", request.Image);
            }
            Guid? parentId = null;
            if (!string.IsNullOrEmpty(request.ParentId))
            {
                parentId = Guid.Parse(request.ParentId);
            }
            Category category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                ParentId = parentId,
                Image = image,
            };

            await _categoryRepository.AddAsync(category);
            return category;
        }

    }
}
