namespace Application.Features.CQRS.Results.PricingResults
{
	public class HardRemoveOnePricingCommandResult
	{
        public int Id { get; set; }

		public HardRemoveOnePricingCommandResult(int id)
		{
			Id = id;
		}
	}
}
