namespace E_Commerce.Application.Features.Categories.Queries.GetCategories
{
    public record GetCategoriesCommand : IRequest<IEnumerable<CategoryDto>>;
}
