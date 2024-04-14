using Domain.Entities.Abstracts;

namespace Domain.Entities.Concrete
{
	public class CarDescription : BaseEntity,IEntity
	{
        public int CarId { get; set; }
        public Car Car { get; set; }
        public string Description { get; set; }

    }
}
