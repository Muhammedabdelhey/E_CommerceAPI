using E_Commerce.Domain.Comman;

namespace E_Commerce.Domain.Entities
{
    public class Attribute : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public ICollection<Category> Categories { get; set; } = [];
        public ICollection<CategoryAttributes> CategoryAttributess { get; set; } = [];

        public ICollection<ProductVariant> ProductVariants { get; set; } = [];
        public ICollection<ProductVariantAttributes> ProductVariantsAttributes { get; set; } = [];

    }
}
