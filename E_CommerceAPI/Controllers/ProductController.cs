using E_Commerce.Application.Features.Attributes.Queries.GetAttributeById;
using E_Commerce.Application.Features.Products.Commands.CreateProduct;
using E_Commerce.Application.Features.Products.Commands.DeleteProduct;
using E_Commerce.Application.Features.Products.Commands.UpdateProduct;
using E_Commerce.Application.Features.Products.Queries.GetAllProducts;
using E_Commerce.Application.Features.Products.Queries.GetProductById;
using E_Commerce.Application.Features.ProductVariants.Commands.CreateProductVariant;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace E_Commerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var prodcuts = await _mediator.Send(new GetProductsQuery(), cancellationToken);
            return Ok(prodcuts);
        }
        [HttpGet("{guid}")]
        public async Task<IActionResult> Get(string guid, CancellationToken cancellationToken)
        {
            var prodcut = await _mediator.Send(new GetProductByIdQuery(guid), cancellationToken);
            return Ok(prodcut);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _mediator.Send(command, cancellationToken);
            return Ok(product);
        }
        [HttpPut("{guid}")]
        public async Task<IActionResult> Update(string guid, [FromForm] UpdateProductCommand command
            , CancellationToken cancellationToken)
        {
            if (!guid.Equals(command.guid))
            {
                return BadRequest("Guid you pass in route not equal to one passed on request");
            }
            var product = await _mediator.Send(command, cancellationToken);
            return Ok(product);
        }
        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete(string guid, CancellationToken cancellationToken)
        {
            var product = await _mediator.Send(new DeleteProductCommand(guid), cancellationToken);
            return Ok($"Product with guid {product.Id} Deleted ");
        }

        [HttpPost("{product_id}/productVariant")]
        public async Task<IActionResult> AddProductVariant([FromRoute] string product_id,
            [FromForm] CreateProductVariantCommand command,
            CancellationToken cancellationToken)
        {
            if (!product_id.Equals(command.ProductId))
            {
                return BadRequest("Guid you pass in route not equal to one passed on request");
            }
            var productVariant = await _mediator.Send(command, cancellationToken);
            return Ok(productVariant);
        }

    }
}

