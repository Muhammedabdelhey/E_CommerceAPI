﻿namespace E_Commerce.Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator(EntityExistenceValidator<Brand> brandExistenceValidator)
        {
            RuleFor(v => v.guid)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.guid)
                       .SetValidator(brandExistenceValidator);
                });

            RuleFor(v => v.Name)
                    .ValidateString(50);

            When(v => v.Image != null, () =>
            {
                RuleFor(v => v.Image)
                    .SetValidator(new ImageValidator());
            });

        }
    }
}
