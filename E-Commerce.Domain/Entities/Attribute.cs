namespace E_Commerce.Domain.Entities
{
    public class Attribute : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<ProductVariant> ProductVariants { get; set; } = [];
        public virtual ICollection<ProductVariantAttributes> ProductVariantsAttributes { get; set; } = [];
    }
}