using E_Commerce.Application.Features.Categories.Commands.CreateCategory;
using E_Commerce.Application.Features.Categories.Commands.DeleteCategory;
using E_Commerce.Application.Features.Categories.Commands.UpdateCategory;
using E_Commerce.Application.Features.Categories.Queries.GetCategories;
using E_Commerce.Application.Features.Categories.Queries.GetCategoryById;

namespace E_Commerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public CategoryController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [Authorize(Policy = nameof(Permissions.Category_Read))]
        [HttpGet("{Guid}")]
        public async Task<IActionResult> Get(string Guid, CancellationToken cancellationToken)
        {
            var category = await _mediatR.Send(new GetCategoryByIdQuery(Guid), cancellationToken);
            return Ok(category);
        }

        [Authorize(Policy = nameof(Permissions.Category_Read))]
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var categories = await _mediatR.Send(new GetCategoriesQuery(), cancellationToken);
            return Ok(categories);
        }

        [Authorize(Policy = nameof(Permissions.Category_Write))]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await _mediatR.Send(command, cancellationToken);
            return StatusCode(StatusCodes.Status201Created, category);
        }

        [Authorize(Policy = nameof(Permissions.Category_Write))]
        [HttpPut("{Guid}")]
        public async Task<IActionResult> Update(
            string Guid,
            [FromForm] UpdateCategoryCommand command,
            CancellationToken cancellationToken)
        {
            if (!Guid.Equals(command.Guid))
            {
                return BadRequest("Guid you pass in route not equal to one passed on request");
            }
            var category = await _mediatR.Send(command, cancellationToken);
            return Ok(category);
        }

        [Authorize(Policy = nameof(Permissions.Category_Delete))]
        [HttpDelete("{Guid}")]
        public async Task<IActionResult> Delete(string Guid, CancellationToken cancellationToken)
        {
            await _mediatR.Send(new DeleteCategoryCommand(Guid), cancellationToken);
            return NoContent();
        }
    }
}
