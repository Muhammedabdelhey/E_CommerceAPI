using E_Commerce.Application.Features.Brands.Commands.CreateBrand;
using E_Commerce.Application.Features.Brands.Commands.DeleteBrand;
using E_Commerce.Application.Features.Brands.Commands.UpdateBrand;
using E_Commerce.Application.Features.Brands.Queries;
using E_Commerce.Application.Features.Brands.Queries.GetBrands;
using E_Commerce.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Policy =nameof(Permissions.Brand_Read))]
        [HttpGet("{guid}")]
        public async Task<IActionResult> Get(string guid, CancellationToken cancellationToken)
        {
            var brand = await _mediator.Send(new GetBrandByIdQuery(guid), cancellationToken);
            return Ok(brand);
        }

        [Authorize(Policy = nameof(Permissions.Brand_Read))]
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var brands = await _mediator.Send(new GetBrandsQuery(), cancellationToken);
            return Ok(brands);
        }

        [Authorize(Policy = nameof(Permissions.Brand_Write))]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBrandCommand command
            , CancellationToken cancellationToken)
        {
            var brand = await _mediator.Send(command, cancellationToken);
            return Ok(brand);
        }

        [Authorize(Policy = nameof(Permissions.Brand_Write))]
        [HttpPut("{guid}")]
        public async Task<IActionResult> Update(
            string guid,
            [FromForm] UpdateBrandCommand command,
            CancellationToken cancellationToken)
        {
            if (!guid.Equals(command.guid))
            {
                return BadRequest("Guid you pass in route not equal to one passed on request");
            }
            var brand = await _mediator.Send(command, cancellationToken);
            return Ok(brand);
        }

        [Authorize(Policy = nameof(Permissions.Brand_Delete))]
        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete(string guid, CancellationToken cancellationToken)
        {
            var brand = await _mediator.Send(new DeleteBrandCommand(guid), cancellationToken);
            return Ok($"Brand with guid {brand.Id} deleted ");
        }
    }
}
