namespace E_Commerce.Models
{
    public class Category : BaseEntity
    {
        public string? Image { get; set; }

        public Guid? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public Category? Parent { get; set; }
        public ICollection<Product> Products { get; set; }= new List<Product>();
        public ICollection<Category> Children { get; set; } = new List<Category>();
        public ICollection<Attribute> Attributes { get; set; } = new List<Attribute>();
        public ICollection<CategoryAttribute> CategoryAttributes { get; set; } = new List<CategoryAttribute>();
    }
}
