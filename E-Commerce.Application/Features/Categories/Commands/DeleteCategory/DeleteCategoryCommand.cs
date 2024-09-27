namespace E_Commerce.Application.Features.Categories.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(string guid) : IRequest<CategoryDto>;

}
