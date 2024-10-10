namespace E_Commerce.Infrastructure.Data.Configurations
{
    public class AttributesConfigurations : IEntityTypeConfiguration<Attribute>
    {
        public void Configure(EntityTypeBuilder<Attribute> builder)
        {
            // configure Many To Many Relationship between ProductVariant and Attributes
            builder.HasMany(a => a.ProductVariants)
                .WithMany(a => a.Attributes)
                .UsingEntity<ProductVariantAttributes>();
        }
    }
}
