using Domain.Entities.Abstracts;

namespace Domain.Entities.Concrete
{
	public class Feature : BaseEntity,IEntity
	{
		public string Name { get; set; }
		public ICollection<CarFeature> CarFeatures { get; set; }
	}
}
