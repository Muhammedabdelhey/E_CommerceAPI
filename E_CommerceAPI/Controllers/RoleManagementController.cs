using E_Commerce.Application.Features.RoleManagement.Commands.CreateRole;
using E_Commerce.Application.Features.RoleManagement.Commands.DeleteRole;
using E_Commerce.Application.Features.RoleManagement.Commands.ManageRoleClaims;
using E_Commerce.Application.Features.RoleManagement.Queries.GetRoleClaims;
using E_Commerce.Application.Features.RoleManagement.Queries.GetRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetRolesQuery(), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleCommand command, CancellationToken cancellationToken)
        {
            var role = await _mediator.Send(command, cancellationToken);
            return Ok(role);
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete(string guid, CancellationToken cancellationToken)
        {
            var role = await _mediator.Send(new DeleteRoleCommand(guid), cancellationToken);
            return Ok($"role {role.Name} was deleted");
        }

        [HttpGet("{guid}/Claims")]
        public async Task<IActionResult> GetRoleClaims(string guid, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetRoleClaimsQuery(guid), cancellationToken));
        }

        [HttpPost("{guid}/Claims")]
        public async Task<IActionResult> CreateRoleClaim(string guid,
             [FromForm]ManageRoleClaimsCommand command,
             CancellationToken cancellationToken)
        {
            if (!guid.Equals(command.RoleId))
            {
                return BadRequest("Guid you pass in route not equal to one passed on request");
            }
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
