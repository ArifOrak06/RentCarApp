using Domain.Entities.Abstracts;

namespace Domain.Entities.Concrete
{
	public class Brand : BaseEntity,IEntity
	{
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
