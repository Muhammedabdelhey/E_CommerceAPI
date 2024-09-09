using E_Commerce.Application.Brands.Commands.CreateBrand;
using E_Commerce.Application.Brands.Commands.DeleteBrand;
using E_Commerce.Application.Brands.Commands.UpdateBrand;
using E_Commerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace E_Commerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBrandCommand command
            , CancellationToken cancellationToken)
        {
            Brand brand = await _mediator.Send(command, cancellationToken);
            return Ok(brand);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] string guid,
            [FromBody] UpdateBrandCommand command
            , CancellationToken cancellationToken)
        {
            if (guid != command.Id)
            {
                return BadRequest();
            }
            Brand brand = await _mediator.Send(command, cancellationToken);
            return Ok(brand);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string guid, CancellationToken cancellationToken)
        {
            if (guid ==null)
            {
                return BadRequest();
            }
            await _mediator.Send(new DeleteBrandCommand(guid));
            return Ok();
        }
    }
}
