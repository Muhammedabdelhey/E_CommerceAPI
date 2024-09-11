using E_Commerce.Application.Attributes.Commands.CreateAttribute;
using E_Commerce.Application.Attributes.Commands.UpdateAttribute;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    }
}
