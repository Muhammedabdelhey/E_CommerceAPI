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
        [HttpGet("{guid}")]
        public async Task<IActionResult> Get(string guid, CancellationToken cancellationToken)
        {
            var prodcut = await _mediator.Send(new GetProductByIdQuery(guid), cancellationToken);
            return Ok(prodcut);
        }

        [Authorize(Policy = nameof(Permissions.Product_Write))]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _mediator.Send(command, cancellationToken);
            return Ok(product);
        }

        [Authorize(Policy = nameof(Permissions.Product_Write))]
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

        [Authorize(Policy = nameof(Permissions.Product_Delete))]
        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete(string guid, CancellationToken cancellationToken)
        {
            var product = await _mediator.Send(new DeleteProductCommand(guid), cancellationToken);
            return Ok($"Product with guid {product.Id} Deleted ");
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
            return Ok(productVariant);
        }

        [Authorize(Policy = nameof(Permissions.Product_Write))]
        [HttpPut("{productId}/productVariant/{productVariantId}")]
        public async Task<IActionResult> UpdateProductVariant(string productVariantId,
            string productId,
            [FromForm] UpdateProductVariantCommand command,
            CancellationToken cancellationToken)
        {
            if (!productId.Equals(command.ProductId) || !productVariantId.Equals(command.guid))
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
            var productVariant = await _mediator.Send(new DeleteProductVariantCommand(productId, productVariantId), cancellationToken);
            return Ok(productVariant);
        }
    }
}

