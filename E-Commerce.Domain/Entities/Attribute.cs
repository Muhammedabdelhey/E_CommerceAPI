using E_Commerce.Domain.Comman;

namespace E_Commerce.Domain.Entities
{
    public class Attribute : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public ICollection<CategoryAttributes> CategoryAttributes { get; set; } = [];
        public ICollection<ProductVariantAttributes> ProductVariantsAttributes { get; set; } = [];
    }
}
