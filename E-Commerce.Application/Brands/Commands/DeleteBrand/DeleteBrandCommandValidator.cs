﻿namespace E_Commerce.Application.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandValidator : AbstractValidator<DeleteBrandCommand>
    {
        public DeleteBrandCommandValidator()
        {
            RuleFor(v => v.Id)
                .SetValidator(new GuidValidator());
        }
    }
}
