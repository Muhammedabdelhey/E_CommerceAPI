using E_Commerce.Domain.Comman;
using E_Commerce.Domain.Interfcases;

namespace E_Commerce.Domain.Entities
{
    public class Category : BaseEntity , IEntityHasImage
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }

        public Guid? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public virtual Category? Parent { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; } = [];

        public virtual ICollection<Product> Products { get; set; } = [];
    }
}