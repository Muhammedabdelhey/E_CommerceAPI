﻿namespace E_Commerce.Infrastructure.Configurations
{
    public class CategoryAttributesConfiguration : IEntityTypeConfiguration<CategoryAttributes>
    {
        public void Configure(EntityTypeBuilder<CategoryAttributes> builder)
        {
            // Configure composite primary key
            builder.HasKey(ca => new { ca.CategoryId, ca.AttributeId });
        }
    }
}