using E_Commerce.Application.Features.Products.Commands.CreateProduct;
using E_Commerce.Application.Features.Products.Commands.CreateProductVariant;
using E_Commerce.Application.Features.Products.Commands.DeleteProduct;
using E_Commerce.Application.Features.Products.Commands.DeleteProductVariant;
using E_Commerce.Application.Features.Products.Commands.UpdateProduct;
using E_Commerce.Application.Features.Products.Commands.UpdateProductVariant;
using E_Commerce.Application.Features.Products.Queries.GetAllProducts;
using E_Commerce.Application.Features.Products.Queries.GetProductById;
using E_Commerce.Application.Features.Products.Queries.GetProductVariants;

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

        [Authorize(Policy = nameof(Permissions.Product_Read))]
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var prodcuts = await _mediator.Send(new GetProductsQuery(), cancellationToken);
            return Ok(prodcuts);
        }

        [Authorize(Policy = nameof(Permissions.Product_Read))]
        [HttpGet("{Guid}")]
        public async Task<IActionResult> Get(string Guid, CancellationToken cancellationToken)
        {
            var prodcut = await _mediator.Send(new GetProductByIdQuery(Guid), cancellationToken);
            return Ok(prodcut);
        }

        [Authorize(Policy = nameof(Permissions.Product_Write))]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _mediator.Send(command, cancellationToken);
            return StatusCode(StatusCodes.Status201Created, product);
        }

        [Authorize(Policy = nameof(Permissions.Product_Write))]
        [HttpPut("{Guid}")]
        public async Task<IActionResult> Update(string Guid, [FromForm] UpdateProductCommand command
            , CancellationToken cancellationToken)
        {
            if (!Guid.Equals(command.Guid))
            {
                return BadRequest("Guid you pass in route not equal to one passed on request");
            }
            var product = await _mediator.Send(command, cancellationToken);
            return Ok(product);
        }

        [Authorize(Policy = nameof(Permissions.Product_Delete))]
        [HttpDelete("{Guid}")]
        public async Task<IActionResult> Delete(string Guid, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteProductCommand(Guid), cancellationToken);
            return NoContent();
        }

        [Authorize(Policy = nameof(Permissions.Product_Read))]
        [HttpGet("{productId}/productVariant")]
        public async Task<IActionResult> GetProuctVariants(string productId, CancellationToken cancellationToken)
        {
            var productVariants = await _mediator.Send(new GetProductVariantsQuery(productId), cancellationToken);
            return Ok(productVariants);
        }

        [Authorize(Policy = nameof(Permissions.Product_Write))]
        [HttpPost("{productId}/productVariant")]
        public async Task<IActionResult> AddProductVariant(
            string productId,
            [FromForm] CreateProductVariantCommand command,
            CancellationToken cancellationToken)
        {
            if (!productId.Equals(command.ProductId))
            {
                return BadRequest("Guid you pass in route not equal to one passed on request");
            }
            var productVariant = await _mediator.Send(command, cancellationToken);
            return StatusCode(StatusCodes.Status201Created, productVariant);
        }

        [Authorize(Policy = nameof(Permissions.Product_Write))]
        [HttpPut("{productId}/productVariant/{productVariantId}")]
        public async Task<IActionResult> UpdateProductVariant(string productVariantId,
            string productId,
            [FromForm] UpdateProductVariantCommand command,
            CancellationToken cancellationToken)
        {
            if (!productId.Equals(command.ProductId) || !productVariantId.Equals(command.Guid))
            {
                return BadRequest("Guid you pass in route not equal to one passed on request");
            }
            var productVariant = await _mediator.Send(command, cancellationToken);
            return Ok(productVariant);
        }

        [Authorize(Policy = nameof(Permissions.Product_Delete))]
        [HttpDelete("{productId}/productVariant/{productVariantId}")]
        public async Task<IActionResult> DeleteProductVariant(string productVariantId,
            string productId,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteProductVariantCommand(productId, productVariantId), cancellationToken);
            return NoContent();
        }
    }
}

