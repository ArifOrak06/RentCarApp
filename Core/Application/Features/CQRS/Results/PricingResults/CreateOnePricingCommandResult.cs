using Domain.Entities.Concrete;

namespace Application.Features.CQRS.Results.PricingResults
{
	public class CreateOnePricingCommandResult
	{
		public int Id { get; set; }
		public List<CarPricing> CarPricings { get; set; }
		public DateTime CraetedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
	}
}
