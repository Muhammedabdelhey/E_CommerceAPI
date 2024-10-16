﻿using E_Commerce.Application.Features.Categories.Commands.CreateCategory;
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
        [HttpGet("{guid}")]
        public async Task<IActionResult> Get(string guid, CancellationToken cancellationToken)
        {
            var category = await _mediatR.Send(new GetCategoryByIdQuery(guid), cancellationToken);
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
            return Ok(category);
        }

        [Authorize(Policy = nameof(Permissions.Category_Write))]
        [HttpPut("{guid}")]
        public async Task<IActionResult> Update(
            string guid,
            [FromForm] UpdateCategoryCommand command,
            CancellationToken cancellationToken)
        {
            if (!guid.Equals(command.guid))
            {
                return BadRequest("Guid you pass in route not equal to one passed on request");
            }
            var category = await _mediatR.Send(command, cancellationToken);
            return Ok(category);
        }

        [Authorize(Policy = nameof(Permissions.Category_Delete))]
        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete(string guid, CancellationToken cancellationToken)
        {
            var category = await _mediatR.Send(new DeleteCategoryCommand(guid), cancellationToken);
            return Ok($"Category with guid {category.Id} deleted ");
        }
    }
}
