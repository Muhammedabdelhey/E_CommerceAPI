using E_Commerce.Application.Features.Authentication.Commands.RefreshToken;
using E_Commerce.Application.Features.Authentication.Commands.SignIn;
using E_Commerce.Application.Features.Authentication.Commands.SignUp;

namespace E_Commerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromForm] SignUpCommand command, CancellationToken cancellationToken)
        {
            var token = await _mediator.Send(command, cancellationToken);
            return Ok(token);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromForm] SignInCommand command, CancellationToken cancellationToken)
        {
            var token = await _mediator.Send(command, cancellationToken);
            return Ok(token);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand command, CancellationToken cancellationToken)
        {
            var token = await _mediator.Send(command, cancellationToken);
            return Ok(token);
        }
    }
}
