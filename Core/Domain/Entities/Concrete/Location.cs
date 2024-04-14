using Domain.Entities.Abstracts;

namespace Domain.Entities.Concrete
{
	public class Location : BaseEntity,IEntity
	{
        public string Name { get; set; }
    }
}
