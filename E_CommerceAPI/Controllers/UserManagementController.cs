using E_Commerce.Application.Features.User_Management.Commands.UserRoles;
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

        [HttpPost]
        public async Task<IActionResult> AddUserRoles(UserRolesCommand command,CancellationToken cancellationToken)
        {
            var roles = await _mediator.Send(command,cancellationToken);
            return Ok(roles);
        }
    }
}
