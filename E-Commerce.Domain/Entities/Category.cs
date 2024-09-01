using E_Commerce.Domain.Comman;

namespace E_Commerce.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }

        public Guid? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public Category? Parent { get; set; }
        public ICollection<Category> Childrens { get; set; } = [];

        public ICollection<Product> Products { get; set; } = [];
        public ICollection<Attribute> Attributes { get; set; } = [];
        public ICollection<CategoryAttributes> CategoryAttributes { get; set; } = [];
    }
}
