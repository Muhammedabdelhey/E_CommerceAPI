using E_Commerce.Domain.Comman;

namespace E_Commerce.Domain.Entities
{
    public class Brand : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }
    }
}
