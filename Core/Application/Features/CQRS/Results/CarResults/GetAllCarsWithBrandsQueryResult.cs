using Domain.Entities.Concrete;

namespace Application.Features.CQRS.Results.CarResults
{
	public class GetAllCarsWithBrandsQueryResult
	{
		public int Id { get; set; }
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
		public ICollection<CarDescription> CarDescriptions { get; set; }
	}
}
