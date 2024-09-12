using E_Commerce.Application.Attributes.Commands.CreateAttribute;
using E_Commerce.Application.Attributes.Commands.DeleteAttribute;
using E_Commerce.Application.Attributes.Commands.UpdateAttribute;
using E_Commerce.Application.Attributes.Queries.GetAttributeById;
using E_Commerce.Application.Attributes.Queries.GetAttributs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AttributeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var attributes = await _mediator.Send(new GetAttributesQuery(),cancellationToken);
            return Ok(attributes);
        }

        [HttpGet("get{guid}")]
        public async Task<IActionResult> Get(string guid,CancellationToken cancellationToken)
        {
            var attributes = await _mediator.Send(new GetAttributeByIdQuery(guid), cancellationToken);
            return Ok(attributes);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAttributeCommand command, CancellationToken cancellationToken)
        {
            var attribute = await _mediator.Send(command, cancellationToken);
            return Ok(attribute);
        }
        [HttpPut("{guid}")]
        public async Task<IActionResult> Update(string guid, [FromBody] UpdateAttributeCommand command,
            CancellationToken cancellationToken)
        {
            if (guid != command.Guid)
            {
                return BadRequest("Guid not Equal guid on attribute");
            }
            var attribute = await _mediator.Send(command, cancellationToken);
            return Ok(attribute);
        }
        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete(string guid, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteAttributeCommand(guid), cancellationToken);
            return Ok("Attribute Deleted");
        }
    }
}
