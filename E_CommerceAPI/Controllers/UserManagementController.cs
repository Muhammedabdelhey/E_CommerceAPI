using E_Commerce.Application.Features.User_Management.Commands.UserClaims;
using E_Commerce.Application.Features.User_Management.Commands.UserRoles;
using E_Commerce.Application.Features.User_Management.Queries.GetUserClaims;
using E_Commerce.Application.Features.User_Management.Queries.GetUserRoles;
using E_Commerce.Application.Features.User_Management.Queries.GetUsers;
using E_Commerce.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers
{
    [Authorize(Roles = nameof(Roles.SuperAdmin))]
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

        [HttpGet("Users/{user_id}/Claims")]
        public async Task<IActionResult> GetUserClaims(string user_id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetUserClaimsQuery(user_id), cancellationToken));
        }

        [HttpGet("Users/{user_id}/Roles")]
        public async Task<IActionResult> GetUserRoles(string user_id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetUserRolesQuery(user_id), cancellationToken));
        }

        [HttpPost("Users/{user_id}/Roles")]
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

        [HttpPost("Users/{user_id}/Claims")]
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
