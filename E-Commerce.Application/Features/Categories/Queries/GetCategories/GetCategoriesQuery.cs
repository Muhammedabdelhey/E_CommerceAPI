namespace E_Commerce.Application.Features.Categories.Queries.GetCategories
{
    public record GetCategoriesQuery : IRequest<IEnumerable<CategoryDto>>;
}
