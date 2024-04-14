using Domain.Entities.Abstracts;

namespace Domain.Entities.Concrete
{
	public class Category : BaseEntity,IEntity
	{
        public string Name { get; set; }
    }
}
