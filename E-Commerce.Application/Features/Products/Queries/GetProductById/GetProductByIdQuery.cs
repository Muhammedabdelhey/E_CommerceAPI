﻿namespace E_Commerce.Application.Features.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(string guid) : IRequest<ProductDto>;
}