using E_Commerce.Application.Common.Validator;

namespace E_Commerce.Application.Features.ProductVariants.Commands.CreateProductVariant
{
    public class CreateProductVariantCommandValidator : AbstractValidator<CreateProductVariantCommand>
    {
        public CreateProductVariantCommandValidator(EntityExistenceValidator<Product> productExistenceValidator,
            EntityExistenceValidator<Attribute> attributeExistenceValidator)
        {

            RuleFor(v => v.ProductId)
                .NotEmpty()
                .SetValidator(new GuidValidator())
                .DependentRules(() =>
                {
                    RuleFor(v => v.ProductId)
                        .SetValidator(productExistenceValidator);
                });

            RuleFor(v => v.Stock)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);

            RuleFor(v => v.Price)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);

            When(v => v.Image != null, () =>
            {
                RuleFor(v => v.Image)
                    .SetValidator(new ImageValidator());
            });

            RuleFor(v => v.Attributes)
                .NotEmpty();

            RuleForEach(v => v.Attributes)
                .ChildRules(attribute =>
                {
                    attribute.RuleFor(a => a.Guid)
                       .NotEmpty()
                       .SetValidator(new GuidValidator())
                       .DependentRules(() =>
                       {
                           attribute.RuleFor(a => a.Guid)
                               .SetValidator(attributeExistenceValidator);
                       });
                    attribute.RuleFor(a => a.Value)
                        .NotEmpty();
                });
        }
    }
}
