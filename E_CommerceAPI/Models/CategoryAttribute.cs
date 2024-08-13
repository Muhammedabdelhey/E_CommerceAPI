namespace E_Commerce.Models
{
    [PrimaryKey(nameof(CategoryId),nameof(AttributeId))]
    public class CategoryAttribute
    {
        public Guid CategoryId { get; set; }
        public Guid AttributeId {  get; set; }
    }
}
