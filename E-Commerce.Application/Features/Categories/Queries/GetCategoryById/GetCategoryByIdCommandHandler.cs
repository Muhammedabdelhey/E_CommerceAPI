
namespace E_Commerce.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdCommandHandler : IRequestHandler<GetCategoryByIdCommand, CategoryDto>
    {
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        public GetCategoryByIdCommandHandler(IBaseRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(Guid.Parse(request.guid));
            if (category == null)
            {
                throw new NotFoundException($"Category with guid {request.guid} not found");
            }
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
