namespace E_Commerce.Models
{
    public class Image : BaseEntity
    {
        public Guid ProductVariantId { get; set; }
        [ForeignKey(nameof(ProductVariantId))]
        public required ProductVariant ProductVariant { get; set; }
    }
}
