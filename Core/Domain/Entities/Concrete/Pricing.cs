using Domain.Entities.Abstracts;

namespace Domain.Entities.Concrete
{
	public class Pricing : BaseEntity,IEntity
	{
		public string Name { get; set; }
        public ICollection<CarPricing> CarPricings { get; set; }

    }
}
