﻿namespace E_Commerce.Application.Features.Attributes.Queries.GetAttributeById
{
    public record GetAttributeByIdQuery(string Guid) : IRequest<AttributeDto>;
}
