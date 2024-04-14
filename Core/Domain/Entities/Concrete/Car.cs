using Domain.Entities.Abstracts;

namespace Domain.Entities.Concrete
{
	public class Car : BaseEntity,IEntity
	{
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Kilometers { get; set; }
        public string Transmission { get; set; }
        public int Luggage { get; set; }
        public int Seat { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
        public ICollection<CarFeature> CarFeatures { get; set; }
        public ICollection<CarDescription> CarDescriptions { get; set; }
		public ICollection<CarPricing> CarPricings { get; set; }
	}
}
