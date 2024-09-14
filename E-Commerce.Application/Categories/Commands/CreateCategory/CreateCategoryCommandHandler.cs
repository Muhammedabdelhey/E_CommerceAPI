
namespace E_Commerce.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
    {
        private readonly IBaseRepository<Category> _categoryRepository;

        public CreateCategoryCommandHandler(IBaseRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                ParentId = string.IsNullOrEmpty(request.ParentId) ? null : Guid.Parse(request.ParentId),
                Image = request.Image,
            };
            await _categoryRepository.AddAsync(category);
            return category;
        }
    }
}
