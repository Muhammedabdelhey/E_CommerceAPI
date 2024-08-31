using E_Commerce.Domain.Comman;

namespace E_Commerce.Domain.Entities
{
    public class Coupon : BaseEntity
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

    }
}
