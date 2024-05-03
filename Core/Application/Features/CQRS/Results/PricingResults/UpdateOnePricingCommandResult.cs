using Domain.Entities.Concrete;

namespace Application.Features.CQRS.Results.PricingResults
{
	public class UpdateOnePricingCommandResult
	{
		public int Id { get; set; }
		public List<CarPricing> CarPricings { get; set; }
		public DateTime ModifiedDate { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
	}
}
