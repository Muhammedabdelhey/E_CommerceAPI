namespace E_Commerce.Domain.Entities
{
    public class Product : BaseAuditableEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public Guid BrandId { get; set; }
        [ForeignKey(nameof(BrandId))]
        public virtual Brand Brand { get; set; }

        public virtual ICollection<ProductVariant> Variants { get; set; } = [];
    }
}
