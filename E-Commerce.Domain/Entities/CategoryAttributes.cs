namespace E_Commerce.Domain.Entities
{
    public class CategoryAttributes
    {
        public Guid CategoryId { get; set; }
        public Guid AttributeId { get; set; }
        public virtual required Category Category { get; set; }
        public virtual required Attribute Attribute { get; set; }
    }
}
