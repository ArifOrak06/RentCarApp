using Domain.Entities.Abstracts;

namespace Domain.Entities.Concrete
{
	public class CarPricing : IEntity
	{
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public Pricing Pricing { get; set; }
        public int PricingId { get; set; }
        public decimal Amount { get; set; }
    }
}
