using Domain.Entities.Concrete;

namespace Application.Features.CQRS.Results.CarDescriptionResults
{
	public class GetAllCarDescriptionsWithCarsQueryResult
	{
        public int Id { get; set; }
        public int CarId { get; set; }
		public Car Car { get; set; }
		public string Description { get; set; }
	}
}
