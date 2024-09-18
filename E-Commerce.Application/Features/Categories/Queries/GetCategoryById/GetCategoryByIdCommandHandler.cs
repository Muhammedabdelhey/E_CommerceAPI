
namespace E_Commerce.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdCommandHandler : IRequestHandler<GetCategoryByIdCommand, Category>
    {
        private readonly IBaseRepository<Category> _categoryRepository;

        public GetCategoryByIdCommandHandler(IBaseRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(GetCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            var category =await  _categoryRepository.GetByIdAsync(Guid.Parse(request.guid));
            if (category == null)
            {
                throw new NotFoundException($"Category with guid {request.guid} not found");
            }
            return category;
        }
    }
}
