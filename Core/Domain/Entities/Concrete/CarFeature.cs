using Domain.Entities.Abstracts;

namespace Domain.Entities.Concrete
{
	public class CarFeature : IEntity
	{
        public int Id { get; set; }
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
