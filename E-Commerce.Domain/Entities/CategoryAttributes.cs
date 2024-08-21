namespace E_Commerce.Domain.Entities
{
    [PrimaryKey(nameof(CategoryId),nameof(AttributeId))]
    public class CategoryAttributes
    {
        public Guid CategoryId { get; set; }
        public Guid AttributeId {  get; set; }
    }
}
