using E_Commerce.Domain.Comman;

public class Attribute : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    // Correct navigation property
    public virtual ICollection<Category> Categories { get; set; } = [];
    public virtual ICollection<CategoryAttributes> AttributeCategories { get; set; } = [];

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = [];
    public virtual ICollection<ProductVariantAttributes> ProductVariantsAttributes { get; set; } = [];
}