using E_Commerce.Application.Features.User_Management.Commands.UserClaims;
using E_Commerce.Application.Features.User_Management.Commands.UserRoles;
using E_Commerce.Application.Features.User_Management.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Users")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetUsersQuery(), cancellationToken));
        }

        [HttpPost("{user_id}/Roles")]
        public async Task<IActionResult> AddUserRoles(string user_id,
            [FromForm] UserRolesCommand command,
            CancellationToken cancellationToken)
        {
            if (!user_id.Equals(command.UserId))
            {
                return BadRequest("Guid you pass in route not equal to one passed on request");
            }
            var roles = await _mediator.Send(command, cancellationToken);
            return Ok(roles);
        }

        [HttpPost("{user_id}/Claims")]
        public async Task<IActionResult> AddUserClaims(string user_id,
            [FromForm] UserClaimsCommand command,
            CancellationToken cancellationToken)
        {
            if (!user_id.Equals(command.UserId))
            {
                return BadRequest("Guid you pass in route not equal to one passed on request");
            }
            var claims = await _mediator.Send(command, cancellationToken);
            return Ok(claims);
        }
    }
}
