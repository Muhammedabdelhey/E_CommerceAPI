using E_Commerce.Application.Features.Attributes.Commands.CreateAttribute;
using E_Commerce.Application.Features.Attributes.Commands.DeleteAttribute;
using E_Commerce.Application.Features.Attributes.Commands.UpdateAttribute;
using E_Commerce.Application.Features.Attributes.Queries.GetAttributeById;
using E_Commerce.Application.Features.Attributes.Queries.GetAttributs;
using E_Commerce.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Policy = nameof(Permissions.Attribute_Read))]
        [HttpGet("{guid}")]
        public async Task<IActionResult> Get(string guid, CancellationToken cancellationToken)
        {
            var attributes = await _mediator.Send(new GetAttributeByIdQuery(guid), cancellationToken);
            return Ok(attributes);
        }

        [Authorize(Policy = nameof(Permissions.Attribute_Read))]
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var attributes = await _mediator.Send(new GetAttributesQuery(), cancellationToken);
            return Ok(attributes);
        }

        [Authorize(Policy = nameof(Permissions.Attribute_Write))]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateAttributeCommand command, CancellationToken cancellationToken)
        {
            var attribute = await _mediator.Send(command, cancellationToken);
            return Ok(attribute);
        }

        [Authorize(Policy = nameof(Permissions.Attribute_Write))]
        [HttpPut("{guid}")]
        public async Task<IActionResult> Update(string guid, [FromForm] UpdateAttributeCommand command,
            CancellationToken cancellationToken)
        {
            if (!guid.Equals(command.Guid))
            {
                return BadRequest("Guid you pass in route not equal to one passed on request");
            }
            var attribute = await _mediator.Send(command, cancellationToken);
            return Ok(attribute);
        }

        [Authorize(Policy = nameof(Permissions.Attribute_Delete))]
        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete(string guid, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteAttributeCommand(guid), cancellationToken);
            return Ok("Attribute Deleted");
        }
    }
}
