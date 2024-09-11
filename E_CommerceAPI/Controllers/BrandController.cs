using E_Commerce.Application.Brands.Commands.CreateBrand;
using E_Commerce.Application.Brands.Commands.DeleteBrand;
using E_Commerce.Application.Brands.Commands.UpdateBrand;
using E_Commerce.Application.Brands.Queries;
using E_Commerce.Application.Brands.Queries.GetBrands;
using E_Commerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] string guid, CancellationToken cancellationToken)
        {
            var brand = await _mediator.Send(new GetBrandByIdQuery(guid), cancellationToken);
            return Ok(brand);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var brands = await _mediator.Send(new GetBrandsQuery(), cancellationToken);
            return Ok(brands);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBrandCommand command
            , CancellationToken cancellationToken)
        {
            Brand brand = await _mediator.Send(command, cancellationToken);
            return Ok(brand);
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> Update(string guid,
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

        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete(string guid, CancellationToken cancellationToken)
        {
            if (guid == null)
            {
                return BadRequest();
            }
            await _mediator.Send(new DeleteBrandCommand(guid), cancellationToken);
            return Ok();
        }
    }
}
