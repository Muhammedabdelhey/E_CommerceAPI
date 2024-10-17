namespace E_Commerce.Application.Features.Categories.Queries.GetCategoryById
{
    public record GetCategoryByIdQuery(string Guid) : IRequest<CategoryDto>;
}
