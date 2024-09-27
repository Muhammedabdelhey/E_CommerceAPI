namespace E_Commerce.Application.Features.Categories.Queries.GetCategoryById
{
    public record GetCategoryByIdQuery(string guid) : IRequest<CategoryDto>;
}
