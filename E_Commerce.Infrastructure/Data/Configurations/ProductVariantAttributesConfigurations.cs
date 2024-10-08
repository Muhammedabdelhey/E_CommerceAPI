﻿namespace E_Commerce.Infrastructure.Data.Configurations
{
    internal class ProductVariantAttributesConfigurations : IEntityTypeConfiguration<ProductVariantAttributes>
    {
        public void Configure(EntityTypeBuilder<ProductVariantAttributes> builder)
        {
            // configure Composted Primary Key
            builder.HasKey(pva => new { pva.ProductVariantId, pva.AttributeId });
        }
    }
}
