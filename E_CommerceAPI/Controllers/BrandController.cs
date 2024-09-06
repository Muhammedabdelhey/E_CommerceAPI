﻿using E_Commerce.Application.Brands.Commands.CreateBrand;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBrandCommand command
            , CancellationToken cancellationToken)
        {
            Brand brand = await _mediator.Send(command, cancellationToken);
            return Ok(brand);
        }
    }
}