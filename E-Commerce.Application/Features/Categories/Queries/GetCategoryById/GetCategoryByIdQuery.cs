namespace E_Commerce.Application.Features.Categories.Queries.GetCategoryById
{
    public record GetCategoryByIdQuery(Guid guid) : IRequest<CategoryDto>;
}
