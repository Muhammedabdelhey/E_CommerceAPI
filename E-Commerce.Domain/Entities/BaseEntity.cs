namespace E_Commerce.Domain.Entities
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
