using System.ComponentModel;

namespace E_Commerce.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IBaseRepository<Category> categoryRepository, IFileService fileService, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new()
            {
                Name = request.Name,
                ParentId = request.ParentId != null ? Guid.Parse(request.ParentId) : null,
                Image = await _fileService.UploadFileAsync(request.Image, cancellationToken),
            };
            await _categoryRepository.AddAsync(category, cancellationToken);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
