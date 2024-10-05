using E_Commerce.Application.Features.Coupons.Commands.CreateCoupon;
using E_Commerce.Application.Features.Coupons.Commands.DeleteCoupon;
using E_Commerce.Application.Features.Coupons.Queries.GetActiveCoupons;
using E_Commerce.Application.Features.Coupons.Queries.GetCouponById;
using E_Commerce.Application.Features.Coupons.Queries.GetCoupons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CouponController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var coupons = await _mediator.Send(new GetCouponsQuery(), cancellationToken);
            return Ok(coupons);
        }
        [HttpGet("get-active")]
        public async Task<IActionResult> GetActive(CancellationToken cancellationToken)
        {
            var coupons = await _mediator.Send(new GetActiveCouponsQuery(), cancellationToken);
            return Ok(coupons);
        }
        [HttpGet("{guid}")]
        public async Task<IActionResult> GetById(string guid, CancellationToken cancellationToken)
        {
            var coupon = await _mediator.Send(new GetCouponByIdQuery(guid), cancellationToken);
            return Ok(coupon);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCouponCommand command, CancellationToken cancellationToken)
        {
            var coupon = await _mediator.Send(command, cancellationToken);
            return Ok(coupon);
        }
        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete(string guid,CancellationToken cancellationToken)
        {
            var coupon = await _mediator.Send(new DeleteCouponQuery(guid), cancellationToken);
            return Ok(coupon);
        }
    }
}
