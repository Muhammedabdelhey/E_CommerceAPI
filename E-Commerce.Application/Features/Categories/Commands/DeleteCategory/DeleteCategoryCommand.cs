namespace E_Commerce.Application.Features.Categories.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(string Guid) : IRequest<Unit>;

}
