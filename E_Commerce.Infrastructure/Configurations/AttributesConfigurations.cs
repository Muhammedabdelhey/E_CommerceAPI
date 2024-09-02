namespace E_Commerce.Infrastructure.Configurations
{
    public class AttributesConfigurations : IEntityTypeConfiguration<Attribute>
    {
        public void Configure(EntityTypeBuilder<Attribute> builder)
        {
            // Configure many-to-many relationship between Category and Attributes
            builder.HasMany(a => a.Categories)
                .WithMany(a => a.Attributes)
                .UsingEntity<CategoryAttributes>();

            // configure Many To Many Relationship between ProductVariant and Attributes
            builder.HasMany(a => a.ProductVariants)
                .WithMany(a => a.Attributes)
                .UsingEntity<ProductVariantAttributes>();
        }
    }
}
