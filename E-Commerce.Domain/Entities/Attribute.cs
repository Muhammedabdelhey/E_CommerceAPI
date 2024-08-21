namespace E_Commerce.Domain.Entities
{
    public class Attribute : BaseEntity
    {

        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<CategoryAttributes> CategoryAttributess { get; set; } = new List<CategoryAttributes>();

        public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
        public ICollection<ProductVariantAttributes> ProductVariantsAttributes { get; set; } =
            new List<ProductVariantAttributes>();

    }
}
