using E_Commerce.Application.Features.Categories.Commands.CreateCategory;
using E_Commerce.Application.Features.Categories.Commands.DeleteCategory;
using E_Commerce.Application.Features.Categories.Commands.UpdateCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CetegoryController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public CetegoryController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await _mediatR.Send(command, cancellationToken);
            return Ok(category);
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> Update(string guid,
            [FromForm] UpdateCategoryCommand command,
            CancellationToken cancellationToken)
        {
            if (guid != command.guid)
            {
                return BadRequest("Guid you pass in route not equal to one passed on request");
            }
            var category = await _mediatR.Send(command, cancellationToken);
            return Ok(category);
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete(string guid, CancellationToken cancellationToken)
        {
            var category = await _mediatR.Send(new DeleteCategoryCommand(guid), cancellationToken);
            return Ok($"Category with guid {category.Id} deleted ");
        }
    }
}
