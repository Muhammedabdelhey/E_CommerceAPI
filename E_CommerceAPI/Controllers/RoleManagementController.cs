using E_Commerce.Application.Features.RoleManagement.Commands.CreateRole;
using E_Commerce.Application.Features.RoleManagement.Commands.DeleteRole;
using E_Commerce.Application.Features.RoleManagement.Commands.ManageRoleClaims;
using E_Commerce.Application.Features.RoleManagement.Queries.GetRoleClaims;
using E_Commerce.Application.Features.RoleManagement.Queries.GetRoles;

namespace E_Commerce.Presentation.Controllers
{
    [Authorize(Roles = nameof(Roles.SuperAdmin))]
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
        public async Task<IActionResult> GetAllRoles(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetRolesQuery(), cancellationToken));
        }

        [HttpGet("Permissions")]
        public IActionResult GetPermissions()
        {
            var permissions = Enum.GetValues(typeof(Permissions))
                  .Cast<Permissions>()
                  .Select(p => new
                  {
                      Id = (int)p,
                      Name = p.ToString()
                  }).ToList();
            return Ok(permissions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleCommand command, CancellationToken cancellationToken)
        {
            var role = await _mediator.Send(command, cancellationToken);
            return StatusCode(StatusCodes.Status201Created,role);
        }

        [HttpDelete("{Guid}")]
        public async Task<IActionResult> DeleteRole(string Guid, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteRoleCommand(Guid), cancellationToken);
            return NoContent();
        }

        [HttpGet("{Guid}/Claims")]
        public async Task<IActionResult> GetRoleClaims(string Guid, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetRoleClaimsQuery(Guid), cancellationToken));
        }

        [HttpPost("{Guid}/Claims")]
        public async Task<IActionResult> AddClaimsToRole(string Guid,
             [FromForm] ManageRoleClaimsCommand command,
             CancellationToken cancellationToken)
        {
            if (!Guid.Equals(command.RoleId))
            {
                return BadRequest("Guid you pass in route not equal to one passed on request");
            }
            var claims = await _mediator.Send(command, cancellationToken);
            return StatusCode(StatusCodes.Status201Created,claims);
        }
    }
}
