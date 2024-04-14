using Domain.Entities.Abstracts;

namespace Domain.Entities.Concrete
{
	public class Banner : BaseEntity,IEntity
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }
    }
}
