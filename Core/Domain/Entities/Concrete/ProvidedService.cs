using Domain.Entities.Abstracts;

namespace Domain.Entities.Concrete
{
	public class ProvidedService : BaseEntity,IEntity
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
