namespace E_Commerce.Domain.Entities
{
    public class ProductVariantAttributes
    {
        public Guid ProductVariantId { get; set; }

        public Guid AttributeId { get; set; }
        public  string Value {  get; set; }=string.Empty;
    }
}
