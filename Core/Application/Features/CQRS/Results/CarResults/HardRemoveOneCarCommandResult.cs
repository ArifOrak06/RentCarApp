namespace Application.Features.CQRS.Results.CarResults
{
	public class HardRemoveOneCarCommandResult
	{
        public int Id { get; set; }

		public HardRemoveOneCarCommandResult(int id)
		{
			Id = id;
		}
	}
}
