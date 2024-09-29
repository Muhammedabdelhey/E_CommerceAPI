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
                Id = Guid.NewGuid(),
                Name = request.Name,
                ParentId = Guid.Parse(request.ParentId),
                Image = await _fileService.UploadFileAsync(Constants.Category, request.Image),
                CategoryAttributes = request.AttributeIds
                    .Select(id => new CategoryAttributes { AttributeId = Guid.Parse(id) })
                    .ToList()
            };
            await _categoryRepository.AddAsync(category, cancellationToken);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
