namespace E_Commerce.Models
{
    public class Attribute : BaseEntity
    {
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<CategoryAttribute> CategoryAttributes { get; set; } = new List<CategoryAttribute>();

        public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
        public ICollection<ProductVariantAttribute> ProductVariantsAttributes { get; set; } =
            new List<ProductVariantAttribute>();

    }
}
