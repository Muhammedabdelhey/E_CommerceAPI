namespace E_Commerce.Application.Features.Categories.Queries.GetCategoryById
{
    public record GetCategoryByIdCommand(string guid) : IRequest<Category>;
}
