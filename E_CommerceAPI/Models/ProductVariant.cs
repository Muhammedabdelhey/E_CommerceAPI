namespace E_Commerce.Models
{
    public class ProductVariant : BaseEntity
    {
        [MaxLength(10)]
        [Required]
        public string Sku { get; set; } = string.Empty;
        public int Stock { get; set; }
        public double Price { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public required Product Product { get; set; }
        public ICollection<Image> Images { get; set; }=new List<Image>();
        public ICollection<Attribute> Attributes { get; set; }= new List<Attribute>();
        public ICollection<ProductVariantAttribute> ProductVariantAttributes { get; set; }=new List<ProductVariantAttribute>();


    }
}
