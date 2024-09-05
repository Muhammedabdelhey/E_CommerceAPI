using E_Commerce.Domain.Comman;

public class Attribute : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    // Correct navigation property
    public ICollection<Category> Categories { get; set; } = [];
    public ICollection<CategoryAttributes> CategoryAttributes { get; set; } = [];

    public ICollection<ProductVariant> ProductVariants { get; set; } = [];
    public ICollection<ProductVariantAttributes> ProductVariantsAttributes { get; set; } = [];
}