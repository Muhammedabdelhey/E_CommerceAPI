namespace E_Commerce.Models
{
    [PrimaryKey(nameof(ProductVariantId),nameof(AttributeId))]
    public class ProductVariantAttribute
    {
        public Guid ProductVariantId { get; set; }

        public Guid AttributeId { get; set; }
        public  string Value {  get; set; }=string.Empty;
    }
}
