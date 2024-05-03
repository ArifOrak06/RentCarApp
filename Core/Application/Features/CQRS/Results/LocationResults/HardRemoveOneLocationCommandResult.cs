namespace Application.Features.CQRS.Results.LocationResults
{
	public class HardRemoveOneLocationCommandResult
	{
        public int Id { get; set; }
        public HardRemoveOneLocationCommandResult(int id)
        {
            Id = id;
        }
    }
}
