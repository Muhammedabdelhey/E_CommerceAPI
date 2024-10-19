namespace E_Commerce.Domain.Entities
{
    public class Brand : BaseEntity, IEntityHasImage
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }
        public virtual ICollection<Product> Products { get; set; } = [];
    }
}
