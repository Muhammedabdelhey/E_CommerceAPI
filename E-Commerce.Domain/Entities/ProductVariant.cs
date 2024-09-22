using E_Commerce.Domain.Comman;

namespace E_Commerce.Domain.Entities
{
    public class ProductVariant : BaseEntity
    {
        [MaxLength(10)]
        [Required]
        public string Sku { get; set; } = string.Empty;
        public int Stock { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual required Product Product { get; set; }
        public virtual ICollection<Attribute> Attributes { get; set; } = [];
    }
}
