namespace E_Commerce.Application.Features.Categories.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(Guid guid) : IRequest<CategoryDto>;

}
