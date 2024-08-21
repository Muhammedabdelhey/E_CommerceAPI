namespace E_Commerce.Domain.Entities
{
    public class Coupon : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
