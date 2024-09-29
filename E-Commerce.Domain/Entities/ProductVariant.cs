using E_Commerce.Domain.Comman;
using System.Text.Json.Serialization;
namespace E_Commerce.Domain.Entities
{
    public class ProductVariant : BaseEntity
    {
        public string Sku { get; set; } = string.Empty;
        public int Stock { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        public virtual ICollection<Attribute> Attributes { get; set; } = [];
        public virtual ICollection<ProductVariantAttributes> ProductVariantAttributes { get; set; } = [];
    }
}
