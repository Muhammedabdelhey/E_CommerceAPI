using E_Commerce.Domain.Comman;

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
        public required Category Category { get; set; }
        public Guid BrandId { get; set; }
        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; } = new Brand();
    }
}
