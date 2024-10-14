using E_Commerce.Application.Features.Coupons.Commands.CreateCoupon;
using E_Commerce.Application.Features.Coupons.Commands.DeleteCoupon;
using E_Commerce.Application.Features.Coupons.Commands.UpdateCoupon;
using E_Commerce.Application.Features.Coupons.Queries.GetActiveCoupons;
using E_Commerce.Application.Features.Coupons.Queries.GetCouponById;
using E_Commerce.Application.Features.Coupons.Queries.GetCoupons;
using E_Commerce.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Policy = nameof(Permissions.Coupon_Read))]
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var coupons = await _mediator.Send(new GetCouponsQuery(), cancellationToken);
            return Ok(coupons);
        }

        [Authorize(Policy = nameof(Permissions.Coupon_Read))]
        [HttpGet("get-active")]
        public async Task<IActionResult> GetActive(CancellationToken cancellationToken)
        {
            var coupons = await _mediator.Send(new GetActiveCouponsQuery(), cancellationToken);
            return Ok(coupons);
        }

        [Authorize(Policy = nameof(Permissions.Coupon_Read))]
        [HttpGet("{guid}")]
        public async Task<IActionResult> GetById(string guid, CancellationToken cancellationToken)
        {
            var coupon = await _mediator.Send(new GetCouponByIdQuery(guid), cancellationToken);
            return Ok(coupon);
        }

        [Authorize(Policy = nameof(Permissions.Coupon_Write))]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCouponCommand command, CancellationToken cancellationToken)
        {
            var coupon = await _mediator.Send(command, cancellationToken);
            return Ok(coupon);
        }

        [Authorize(Policy = nameof(Permissions.Coupon_Write))]
        [HttpPut("{guid}")]
        public async Task<IActionResult> Update(string guid,
            [FromForm] UpdateCouponCommand command,
            CancellationToken cancellationToken)
        {
            if (!guid.Equals(command.guid))
            {
                return BadRequest("Guid you pass in route not equal to one passed on request");
            }
            var coupon =await _mediator.Send(Request, cancellationToken);
            return Ok(coupon);
        }

        [Authorize(Policy = nameof(Permissions.Coupon_Delete))]
        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete(string guid, CancellationToken cancellationToken)
        {
            var coupon = await _mediator.Send(new DeleteCouponQuery(guid), cancellationToken);
            return Ok(coupon);
        }
    }
}
