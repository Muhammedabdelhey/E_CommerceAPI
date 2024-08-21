namespace E_Commerce.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string? Image { get; set; }

        public Guid? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public Category? Parent { get; set; }
        public ICollection<Category> Children { get; set; } = new List<Category>();

        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Attribute> Attributes { get; set; } = new List<Attribute>();
        public ICollection<CategoryAttributes> CategoryAttributess { get; set; } = new List<CategoryAttributes>();
    }
}
