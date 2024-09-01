namespace E_Commerce.Infrastructure.Configurations
{
    internal class ProductVariantAttributesConfigurations : IEntityTypeConfiguration<ProductVariantAttributes>
    {
        public void Configure(EntityTypeBuilder<ProductVariantAttributes> builder)
        {
            // configure Composted Primary Key
            builder.HasKey(pva => new { pva.ProductVariantId, pva.AttributeId });

            // configure Many To Many Relationship between ProductVariant and Attributes
            builder.HasOne(pva => pva.ProductVariant)
                .WithMany(pv => pv.ProductVariantAttributess)
                .HasForeignKey(pva => pva.ProductVariantId);

            builder.HasOne(pva => pva.Attribute)
                .WithMany(a => a.ProductVariantsAttributes)
                .HasForeignKey(pva => pva.AttributeId);
        }
    }
}
