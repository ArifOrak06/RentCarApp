namespace Application.Features.CQRS.Results.ContactResults
{
	public class HardRemoveOneContactCommandResult
	{
        public int Id { get; set; }

		public HardRemoveOneContactCommandResult(int id)
		{
			Id = id;
		}
	}
}
