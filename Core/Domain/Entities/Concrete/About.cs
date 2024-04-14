using Domain.Entities.Abstracts;

namespace Domain.Entities.Concrete
{
	public class About : BaseEntity,IEntity
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
