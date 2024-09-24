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
            string? image = null;
            if (request.Image != null)
            {
                image = await _fileService.UploadFileAsync(Constants.Category, request.Image);
            }
            Guid? parentId = null;
            if (request.ParentId is not null)
            {
                parentId = request.ParentId;
            }
            Category category = new()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                ParentId = parentId,
                Image = image,
            };
            if (request.AttributeIds.Any())
            {
                foreach (var attributeId in request.AttributeIds)
                {

                    category.CategoryAttributes.Add(new CategoryAttributes { AttributeId = attributeId });
                }
            }
            await _categoryRepository.AddAsync(category, cancellationToken);
            return _mapper.Map<CategoryDto>(category);
        }

    }
}
