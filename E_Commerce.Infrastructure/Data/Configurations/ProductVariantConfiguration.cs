
namespace E_Commerce.Infrastructure.Data.Configurations
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.HasIndex(pv => pv.Sku)
                .IsUnique();
        }
    }
}
