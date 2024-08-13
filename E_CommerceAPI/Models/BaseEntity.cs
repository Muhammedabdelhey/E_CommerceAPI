namespace E_Commerce.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }= string.Empty;
    }
}
