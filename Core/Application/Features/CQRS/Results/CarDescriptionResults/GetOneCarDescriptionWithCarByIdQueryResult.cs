using Domain.Entities.Concrete;

namespace Application.Features.CQRS.Results.CarDescriptionResults
{
	public class GetOneCarDescriptionWithCarByIdQueryResult
	{
        public int Id { get; set; }
        public int CarId { get; set; }
		public Car Car { get; set; }
		public string Description { get; set; }
	}
}
