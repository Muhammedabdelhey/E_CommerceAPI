namespace E_Commerce.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Category>
    {
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IFileService _fileService;
        public UpdateCategoryCommandHandler(IBaseRepository<Category> categoryRepository, IFileService fileService)
        {
            _categoryRepository = categoryRepository;
            _fileService = fileService;
        }

        public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(Guid.Parse(request.guid), cancellationToken);
            if (category==null)
            {
                throw new NotFoundException($"Category with Guid {request.guid} not found");
            }
            var image=category.Image;
            if (request.Image != null)
            {
                // delete old file then upload it 
                image = await _fileService.UploadFileAsync("category", request.Image);
            }
            throw new NotImplementedException();
        }
    }
}
