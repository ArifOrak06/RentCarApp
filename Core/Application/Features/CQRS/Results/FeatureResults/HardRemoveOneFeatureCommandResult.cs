namespace Application.Features.CQRS.Results.FeatureResults
{
	public class HardRemoveOneFeatureCommandResult
	{
        public int Id { get; set; }
        public HardRemoveOneFeatureCommandResult(int id)
        {
            Id = id;
        }
    }
}
