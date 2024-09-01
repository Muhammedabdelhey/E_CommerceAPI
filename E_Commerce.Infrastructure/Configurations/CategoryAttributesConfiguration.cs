namespace E_Commerce.Infrastructure.Configurations
{
    public class CategoryAttributesConfiguration : IEntityTypeConfiguration<CategoryAttributes>
    {
        public void Configure(EntityTypeBuilder<CategoryAttributes> builder)
        {
            // configure Composted Primary Key
            builder.HasKey(ca => new { ca.CategoryId, ca.AttributeId });

            // configure Many To Many Relationship between Category and Attributes
            builder.HasOne(ca => ca.Category)
                .WithMany(c => c.CategoryAttributes)
                .HasForeignKey(ca => ca.CategoryId);

            builder.HasOne(ca => ca.Attribute)
                .WithMany(a => a.CategoryAttributes)
                .HasForeignKey(ca => ca.AttributeId);
                
        }
    }
}
