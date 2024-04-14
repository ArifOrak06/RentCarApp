using Domain.Entities.Abstracts;

namespace Domain.Entities.Concrete
{
	public class Testimonial : BaseEntity,IEntity
	{
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}
